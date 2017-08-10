pipeline {
    agent {
		label "Build"
	}

    stages {
        stage('DB Restore') {
            steps {
                bat '''sqlcmd -U dev_amilia -P password -S .\\CISQL -Q "RESTORE DATABASE ci%EXECUTOR_NUMBER%_amilia FROM DISK='D:/Unit.db.backups/app.%EXECUTOR_NUMBER%.bak' WITH REPLACE;"
sqlcmd -U dev_amilia -P password -S .\\CISQL -Q "USE master;ALTER DATABASE [ci%EXECUTOR_NUMBER%_logging] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;DROP DATABASE ci%EXECUTOR_NUMBER%_logging;"
sqlcmd -U dev_amilia -P password -S .\\CISQL -Q "CREATE DATABASE ci%EXECUTOR_NUMBER%_logging;"'''
            }
        }
        stage('Nuget Restore') {
            steps {
                bat 'nuget.exe restore amilia.sln'
            }
        }
        stage('Change Connection Strings') {
            steps {
                bat '''nant /f:"Buildfiles/ci.build" -D:ci_string_infix="%EXECUTOR_NUMBER%" -D:CI_Node_Name="%Amilia_Node_Id%" ChangeConnectionStrings'''
            }
        }
    }
}