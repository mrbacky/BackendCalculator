pipeline {
    agent any
	triggers {
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
        stage("Publish") {
            steps {
               sh  "dotnet publish -c Release BackendCalculator.sln"
            }
        }
        stage("Deliver to Docker Hub"){
            steps{
                sh "docker build . -t mrbacky/backend-calc"
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'DockerHub', usernameVariable: 'USERNAME',passwordVariable: 'PASSWORD']])
                {
                    sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                }
                sh "docker push mrbacky/backend-calc"
            }
        }
    }
  }