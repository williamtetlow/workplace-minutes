#!/usr/bin/env python
# -*- coding: utf-8 -*-

"""
Script to process audio using a ported-to-python-3-version of PyAudioAnalysis
"""

import numpy
from pyaudioanalysis.audioSegmentation import speaker_diarization
numpy.random.seed(123)  # for reproducibility

fpath = r'C:\Users\sendh\Documents\Python Projects\GitHub\workplace_minutes\diarization_gateway\tests\input\fish.wav'
cluster_labels = speaker_diarization(filepath=fpath, num_of_speakers=4)



# if 1:
#     # running the python 3 ported version of the tool
#     from diarization_gateway.pyAudioAnalysis.src.py3.audioAnalysis import speakerDiarizationWrapper
#     speakerDiarizationWrapper(fpath, numSpeakers=4, useLDA=False)
#
# else:
#     # attempt to make it work on python2 environment
#     python2path = r'C:\python27\python.exe'
#     pyaudio_path = r'C:\Users\sendh\Documents\Python Projects\GitHub\workplace_minutes\diarization_gateway\pyAudioAnalysis\src\py2\audioAnalysis.py'
#
#     cmd = '"{}" "{}" speakerDiarization -i "{}" --num 4'.format(python2path, pyaudio_path, fpath)
#     #cmd = '"{}"'.format(python2path, pyaudio_path, fpath)
#     import subprocess
#     print(cmd)
#     subprocess.call(cmd.split(' '))
# "C:\python27\python.exe" audioAnalysis.py speakerDiarization -i data\diarizationExample.wav --num 4
