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

export default class UploadRecording extends Component {
	state = {
		isUploading: false,
		uploadProgress: 0
	};

	constructor(props) {
		super(props);
		this.state = {}
	}

	_uploadRecording() {
		//insert log into firebase and then stash file into storage with this id
	}


  render() {
		const recordingPath = this.props.recordingPath;
    return (
			<View style={styles.container}>
				<Text>
					Length: {this.props.recordingLength} Size: {this.props.recordingSize}
				</Text>
				{this.state.isUploading &&
					<Text>
						Progress: {this.state.uploadProgress}
					</Text>
				}
				<Button
					buttonStyle={styles.uploadButton}
					large
					title='Upload'
					onPress={() => this._uploadRecording()} />
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