import React, { 
	Component 
} from 'react';
import {
  StyleSheet,
  Text,
  View,
	ActivityIndicator
} from 'react-native';
import { 
  FormLabel, 
  FormInput, 
  Button 
} from 'react-native-elements'
import firebase from './firebase';

export default class UploadRecording extends Component {
	state = {
		uploading: false,
		uploadProgress: 'N/A'
	};

	_uploadRecording(filePath) {
		this.setState({uploading: true});

		const filename = `recordings/${new Date().getTime()}`;
		const unsubscribe = firebase.storage()
			.ref(filename)
			.putFile(filePath)
			.on('state_changed', 
				snapshot => {
					this.setState({uploadProgress: `${snapshot.bytesTransferred} / ${snapshot.totalBytes}`});
					console.log(snapshot);
				}, 
				err => {
						console.error(err);
						unsubscribe();
				}, 
				uploadedFile => {
						console.log(uploadedFile);
						this.setState({uploadProgress: `Completed (${filename})`});
						unsubscribe();
				});
	}

  render() {
		const recordingPath = this.props.recordingPath;
    return (
			<View style={styles.container}>
				<Text>
					Length: {this.props.recordingLength} Size: {this.props.recordingSize}
				</Text>
				{this.state.uploading &&
					<Text>
						Progress: {this.state.uploadProgress}
					</Text>
				}
				<Button
					buttonStyle={styles.uploadButton}
					large
					title='Upload'
					onPress={() => this._uploadRecording(this.props.recordingPath)} />
			</View>
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
  uploadButton: {
		borderRadius: 10,
		backgroundColor: 'red',
		marginTop: 40
  }
});