#!/usr/bin/env python
# -*- coding: utf-8 -*-

"""
Script to process audio using a ported-to-python-3-version of PyAudioAnalysis
"""

import numpy
from pyaudioanalysis.audioSegmentation import speaker_diarization


class PyAudioAnalysisDiarizationModel:
    name = "pyaudioanalysis"

    @staticmethod
    def run(fpath, num_of_speakers=0):
        cluster_labels = speaker_diarization(filepath=fpath, num_of_speakers=num_of_speakers)
        return cluster_labels


if __name__ == '__main__':
    numpy.random.seed(123)  # for reproducibility
    fpath = r'C:\Users\sendh\Documents\Python Projects\GitHub\workplace_minutes\diarization_gateway\tests\input\diarizationExample.wav'
    cluster_labels = PyAudioAnalysisDiarizationModel.run(fpath)
    print(cluster_labels)
