class MockSpeechToTextV1:
    def __init__(self, *args, **kwargs): pass

    def get_model(self, *args, **kwargs): return {'name': 'Test'}

    def recognize(self, *args, **kwargs):
        return {"results": [{"alternatives": [{"timestamps": [["you have been mocked"]]}]}],
                "speaker_labels": [{"from": 0.03, "to": 0.22, "speaker": 0}]}
