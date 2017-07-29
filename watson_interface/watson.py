#!/usr/bin/env python
# -*- coding: utf-8 -*-

"""
Client-side script to send a file to a provisioned service on BlueMix

Sample template: https://github.com/watson-developer-cloud/python-sdk/blob/master/examples/speech_to_text_v1.py
Speech-to-Text docs: https://www.ibm.com/watson/developercloud/doc/speech-to-text/developer-overview.html
"""

import os
import json
from watson_developer_cloud import SpeechToTextV1

# mock SpeechToTextV1 for TESTING ONLY (comment otherwise)
class SpeechToTextV1:
    def __init__(self, *args, **kwargs): pass
    def get_model(self, *args, **kwargs): return {'name': 'Test'}
    def recognize(self, *args, **kwargs):
        return {"results": [{"alternatives": [{"timestamps": [["you have been mocked"]]}]}],
                "speaker_labels": [{"from": 0.03, "to": 0.22, "speaker": 0}]}


INPUT_FOLDER = os.path.join(os.path.dirname(__file__), "tests", "input")
OUTPUT_FOLDER = os.path.join(os.path.dirname(__file__), "tests", "output")
CREDENTIALS_JSON_PATH = "watson_credentials.json"
RECOGNITION_MODEL = 'en-US_BroadbandModel'  # en-US_BroadbandModel or en-US_NarrowbandModel (for english)


def print_json(x):
    print(json.dumps(x, indent=2))


def save_json(json_data, filepath):
    with open(os.path.join(OUTPUT_FOLDER, filepath), 'w') as fp:
        json.dump(json_data, fp)


def open_json(filepath):
    with open(filepath, 'r') as f:
        data = json.load(f)
    return data


def recognize_with_watson(audio_file_path):
    """
     Uses the IBM-Watson Speech-to-Text API to diarize the input audio file
    """
    credentials = open_json(CREDENTIALS_JSON_PATH)
    speech_to_text = SpeechToTextV1(
        x_watson_learning_opt_out=True,
        **credentials,
    )

    # print_json(speech_to_text.models())
    recognition_model = speech_to_text.get_model(RECOGNITION_MODEL)

    # use the watson API
    with open(audio_file_path, 'rb') as f:
        recognized = speech_to_text.recognize(f,
                                              model=recognition_model['name'],
                                              content_type='audio/mp3',
                                              timestamps=True,
                                              word_confidence=True,
                                              speaker_labels=True)

    # print the json console and save it
    print_json(recognized)
    save_json(recognized, 'recognized_{}.json'.format(recognition_model['name']))


def extract_info_from_recognized_data(fpath, name_map=None):
    """
    Reads the json file of the transcription and shows the result in a more summerized version, like:

    speaker 0 (0.0 - 15.3): "bla bla bla bla"
    speaker 1 (15.3 - 20.7): "yada yada"
    """

    # opening the transcribed file
    data = open_json(fpath)

    # putting all transcribed words together
    transcripts = [ts[0] for r in data['results'] for ts in r['alternatives'][0]['timestamps']]

    # separating by speaker
    speaker_transcripts = []
    previous_speaker = -1
    for label, word in zip(data['speaker_labels'], transcripts):
        if label['speaker'] != previous_speaker:
            previous_speaker = label['speaker']
            if name_map:
                label.update({'speaker': name_map[label['speaker']]})
            else:
                label.update({'speaker': 'speaker {}'.format(label['speaker'])})
            transcript = {'text': word, **label}
            speaker_transcripts.append(transcript)
        else:
            transcript = speaker_transcripts[-1]
            transcript['text'] += ' ' + word
            transcript['to'] = label['to']

    # formatting
    formatted_output = ['{:<10} ({:>7}-{:>7}): "{}"'.format(i['speaker'], i['from'], i['to'], i['text'])
                        for i in speaker_transcripts]

    # printing to console
    for i in formatted_output: print(i)


if __name__ == '__main__':
    import datetime
    start_time = datetime.datetime.now()

    filepath = os.path.join(INPUT_FOLDER, r'fish.mp3')  # 1:53 mp3 audio file
    recognize_with_watson(filepath)

    filepath = os.path.join(OUTPUT_FOLDER, 'recognized_{}.json'.format(RECOGNITION_MODEL))
    name_map = None  # {0: 'James', 1: 'Anna', 2: 'Dan', 3: 'Andy'}  # if unknown: None
    extract_info_from_recognized_data(filepath, name_map=name_map)

    print("Finished: {}".format(datetime.datetime.now()-start_time))
