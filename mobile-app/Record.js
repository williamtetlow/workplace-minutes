import React, { 
	Component 
} from 'react';
import {
  AppRegistry,
  StyleSheet,
  Text,
  View,
  Platform,
  PermissionsAndroid,
} from 'react-native';
import { 
  FormLabel, 
  FormInput, 
  Button 
} from 'react-native-elements'
import {
	AudioRecorder, 
	AudioUtils
} from 'react-native-audio';
import UploadRecording from './UploadRecording';

export default class Record extends Component {
	state = {
    timeRecorded: 0.0,
    recording: false,
    stoppedRecording: false,
    finished: false,
		audioPath: AudioUtils.DocumentDirectoryPath + '/test.aac',
    hasPermission: undefined
	};

	_checkPermission() {
		if (Platform.OS !== 'android') {
			return Promise.resolve(true);
		}

		const rationale = {
			'title': 'Microphone Permission',
			'message': 'WorkplaceMobile needs access to your microphone so you can record audio.'
		};

		return PermissionsAndroid.request(PermissionsAndroid.PERMISSIONS.RECORD_AUDIO, rationale)
			.then((result) => {
				console.log('Permission result:', result);
				return (result === true || result === PermissionsAndroid.RESULTS.GRANTED);
			});
	}

	_prepareRecordingPath(audioPath){
		AudioRecorder.prepareRecordingAtPath(audioPath, {
			SampleRate: 22050,
			Channels: 1,
			AudioQuality: "Low",
			AudioEncoding: "aac",
			AudioEncodingBitRate: 32000
		});
	}

	_finishRecording(didSucceed, filePath) {
		const recordingSize = 0;
		this.setState({ 
			finished: didSucceed,
			recordingLength: this.state.timeRecorded,
			recordingSize: recordingSize
		 });
		console.log(`Finished recording of duration ${this.state.timeRecorded} seconds at path: ${filePath}`);
	}

	async _stopRecording() {
		if (!this.state.recording) {
			console.warn('Can\'t stop, not recording!');
			return;
		}

		this.setState({stoppedRecording: true, recording: false});

		try {
			const filePath = await AudioRecorder.stopRecording();

			if (Platform.OS === 'android') {
				this._finishRecording(true, filePath);
			}
			return filePath;
		} catch (error) {
			console.error(error);
		}
	}

	async _record() {
		if (this.state.recording) {
			console.warn('Already recording!');
			return;
		}

		if (!this.state.hasPermission) {
			console.warn('Can\'t record, no permission granted!');
			return;
		}

		if(this.state.stoppedRecording){
			this._prepareRecordingPath(this.state.audioPath);
		}

		this.setState({recording: true});

		try {
			const filePath = await AudioRecorder.startRecording();
		} catch (error) {
			console.error(error);
		}
	}

	componentDidMount() {
		this._checkPermission().then((hasPermission) => {
			this.setState({ hasPermission });

			if (!hasPermission) return;

			this._prepareRecordingPath(this.state.audioPath);

			AudioRecorder.onProgress = (data) => {
				this.setState({timeRecorded: Math.floor(data.currentTime)});
			};

			AudioRecorder.onFinished = (data) => {
				// Android callback comes in the form of a promise instead.
				if (Platform.OS === 'ios') {
					this._finishRecording(data.status === "OK", data.audioFileURL);
				}
			};
		});
	}

  render() {
		if(!this.state.finished) {
			return (
				<View style={styles.container}>
					<Text
						style={styles.timeRecordedText}>
							{this.state.timeRecorded}s
					</Text>
					<Button
						buttonStyle={styles.recordButton}
						large
						color="red"
						title={!this.state.recording ? 'Start Recording' : 'Complete Recording'}
						onPress={() => !this.state.recording ? this._record() : this._stopRecording()} />
				</View>
			);
		}
    return (
			<UploadRecording
				recordingPath={this.state.audioPath}
				recordingLength={this.state.recordingLength}
				recordingSize={this.state.recordingSize}/>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#F5FCFF',
  },
  timeRecordedText: {
		color: 'black',
		fontSize: 60
  },
  recordButton: {
	  borderColor:"red",
		borderRadius: 3,
		backgroundColor: 'white',
		marginTop: 40,
		borderWidth: 1
		
  }
});