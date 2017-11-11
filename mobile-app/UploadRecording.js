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

	_discardRecording() {
	}
	
	_uploadRecording(filePath) {
		this.setState({uploading: true});

		const filename = `recordings/${new Date().getTime()}`;
		const unsubscribe = firebase.storage()
			.ref(filename)
			.putFile(filePath)
			.on('state_changed', 
				snapshot => {
					//this.setState({uploadProgress: `${snapshot.bytesTransferred} / ${snapshot.totalBytes}`});
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
				<FormLabel>Title</FormLabel>
				<FormInput/>
				<Text>
					Length: {this.props.recordingLength} Size: {this.props.recordingSize}
				</Text>
				{this.state.uploading &&
					<Text>
						Progress: {this.state.uploadProgress}
					</Text>
				}
				<View style={styles.buttonContainer}>
				<Button
					buttonStyle={styles.discardButton}
					large
					icon={{name: 'delete-forever', color: '#E83151'}}
					color="#E83151"
					title='Discard'
					onPress={() => this._discardRecording()} />
				<Button
					buttonStyle={styles.uploadButton}
					large
					icon={{name: 'file-upload', color: '#387780'}}
					color="#387780"
					title='Upload'
					onPress={() => this._uploadRecording(this.props.recordingPath)} />
					</View>
			</View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'stretch',
    backgroundColor: '#FFFFFF',
	},
	buttonContainer: {
		flex: 2,
		flexDirection: 'row',
		justifyContent: 'space-between',
		alignItems: 'stretch'
	},
  uploadButton: {
		borderRadius: 3,
		borderWidth: 3,
		borderColor: "#387780",
		backgroundColor: 'white',
		marginTop: 40
	},
	discardButton: {
		borderRadius: 3,
		borderWidth: 3,
		borderColor: "#E83151",
		backgroundColor: 'white',
		marginTop: 40
  }
});