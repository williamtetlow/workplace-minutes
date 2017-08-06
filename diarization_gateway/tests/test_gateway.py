import pytest
import os
import json
from diarization_gateway.gateway import app
from diarization_gateway.tests.util4tests import MockWatsonDiarizationModel, MockPyAudioAnalysisDiarizationModel

ENABLE_MOCKING = True

# ===================================
# ======== FIXTURES & AUX ===========
get_test_file = lambda x: os.path.join(os.path.dirname(__file__), 'input', x)


@pytest.fixture(scope="module")
def client():
    app.testing = True
    _client = app.test_client()
    if ENABLE_MOCKING:
        app.diarization_models = [MockWatsonDiarizationModel, MockPyAudioAnalysisDiarizationModel]
    return _client


@pytest.fixture(params=['watson', 'pyaudioanalysis'])
def model_name(request):
    return request.param


# ==========================
# ======== TESTS ===========
def test_get_models(client):
    resp = client.get('/models')
    assert json.loads(resp.data) == ['watson', 'pyaudioanalysis']


def test_run_models(client, model_name):
    uri = '/models/{}/run'.format(model_name)
    body = json.dumps(dict(fpath=get_test_file('diarizationExample.wav')))
    resp = client.post(uri, data=body, content_type='application/json')
    assert resp.status == '200 OK'
    assert 'speaker_labels' in json.loads(resp.data)
