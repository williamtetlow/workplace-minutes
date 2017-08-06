from flask import Flask, request
from flask_restplus import Resource, Api, fields

# from diarization_gateway.util import get_request_data
from diarization_gateway.models.pyaudioanalysis_model import PyAudioAnalysisDiarizationModel
from diarization_gateway.models.watson_model import WatsonDiarizationModel

app = Flask(__name__)
app.diarization_models = [WatsonDiarizationModel, PyAudioAnalysisDiarizationModel]
app.config.SWAGGER_UI_DOC_EXPANSION = 'list'
api = Api(app, version='0.1', title='Diarization API',
          description='An API that allows diarization of audio files using different diarization models')

run_conf = api.model('Run Configuration', {
    'fpath': fields.String(description='The full path to the audio file that needs to be diarized'),
    'num_of_speakers': fields.Integer(description='PyAudioAnalysis ONLY and optional')
})


@api.route('/models')
class GetAvailableModels(Resource):
    def get(self):
        """Returns a list of the available models"""
        return [i.name for i in app.diarization_models]


@api.route('/models/<string:model_name>/run')
class RunModel(Resource):
    @api.expect(run_conf)
    @api.response(500, 'Error while processing the audio file')
    def post(self, model_name):
        """Runs the Diarization model selected on the posted audiofile"""
        model = [m for m in app.diarization_models if m.name == model_name]
        if model:
            model_instance = model[0]()
            post_data = request.get_json()  # get_request_data(request)
            diarized_json = model_instance.run(**post_data)
            return diarized_json
        else:
            return "Model not found", 404


if __name__ == '__main__':
    app.run(debug=True)
