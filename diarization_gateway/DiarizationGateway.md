# Diarization Gateway
This part of the application is providing the interface with the multiple diarization models.

## Setup & Run
In order to set it up:
1. Ensure you have installed python and its needed dependencies (see requirements.yml)
0. Activate the environment of the installation in point 1.
0. Run "python diarization_gateway\gateway.py"

## Usage
To access the interactive documentation go to your browser at localhost:5000
In alternative you can send HTTP request to the RESTful API as follows:
- GET request to /models to get the list of active model names
- POST request to /models/<model_name>/run to run the selected model on the 
file provided in the data section of the request. For the moment, the file 
is specified by entering "fpath": <full_path_to_the_file> as key value in the
data portion of the request.

