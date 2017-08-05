#!/usr/bin/env python
# -*- coding: utf-8 -*-

"""
Client-side script to send a file to a provisioned service on BlueMix

Sample template: https://github.com/watson-developer-cloud/python-sdk/blob/master/examples/speech_to_text_v1.py
Speech-to-Text docs: https://www.ibm.com/watson/developercloud/doc/speech-to-text/developer-overview.html
"""

import os
import logging
from diarization_gateway.util import print_json, open_json, save_json
from watson_developer_cloud import SpeechToTextV1

DIARIZATION_GATEWAY_FOLDER = os.path.dirname(os.path.dirname(__file__))
INPUT_FOLDER = os.path.join(DIARIZATION_GATEWAY_FOLDER, "tests", "input")
OUTPUT_FOLDER = os.path.join(DIARIZATION_GATEWAY_FOLDER, "tests", "output")
CREDENTIALS_JSON_PATH = "watson_credentials.json"
RECOGNITION_MODEL = 'en-US_BroadbandModel'  # en-US_BroadbandModel or en-US_NarrowbandModel (for english)

logger = logging.getLogger(__name__)


def recognize_with_watson(audio_file_path):
    """
     Uses the IBM-Watson Speech-to-Text API to diarize the input audio file
    """
    credentials = open_json(CREDENTIALS_JSON_PATH)
    speech_to_text = SpeechToTextV1(
        x_watson_learning_opt_out=True,
        **credentials,
    )

    print_json(speech_to_text.models())
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
    output_json_location = os.path.join(OUTPUT_FOLDER, 'recognized_{}.json'.format(recognition_model['name']))
    save_json(recognized, output_json_location)
    return output_json_location


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
    # --- mock SpeechToTextV1 for TESTING ONLY (comment otherwise) ----
    # from diarization_gateway.tests.util4tests import MockSpeechToTextV1; SpeechToTextV1 = MockSpeechToTextV1
    # -----------------------------------------------------------------
    logging.basicConfig()

    import datetime
    start_time = datetime.datetime.now()

    filepath = os.path.join(INPUT_FOLDER, r'fish.wav')  # 1:53 mp3 audio file
    output_json_location = recognize_with_watson(filepath)

    name_map = None  # {0: 'James', 1: 'Anna', 2: 'Dan', 3: 'Andy'}  # if unknown: None
    extract_info_from_recognized_data(fpath=output_json_location, name_map=name_map)

    print("Finished: {}".format(datetime.datetime.now()-start_time))
