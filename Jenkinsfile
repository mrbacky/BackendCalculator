pipeline {
    agent any
	triggers {
		cron("0 * * * *")
		pollSCM("*/3 * * * *")
	}
		
    stages {
        stage("Build") {
            steps {
                sh "dotnet build BackendCalculator.sln"
            }
        }
        stage("Test") {
            steps {
               sh  "dotnet test BackendCalculator.sln"
            }
        }
        
    }
  }