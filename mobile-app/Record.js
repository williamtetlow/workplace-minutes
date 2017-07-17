import React, { Component } from 'react';
import {
  AppRegistry,
  StyleSheet,
  Text,
  View
} from 'react-native';
import { 
  FormLabel, 
  FormInput, 
  Button 
} from 'react-native-elements'

export default class Record extends Component {
	state = {
    timeRecorded: 0.0,
    recording: false,
    stoppedRecording: false,
    finished: false,
    hasPermission: undefined,
	};

	componentDidMount() {
		//set up audio recorder here
	}

  render() {
    return (
			<View style={styles.container}>
				<Text
					style={styles.timeRecordedText}>
						{this.state.timeRecorded}s
				</Text>
				<Button
					buttonStyle={styles.recordButton}
					large
					title='Start Recording' />
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
  timeRecordedText: {
		color: 'black',
		fontSize: 60
  },
  recordButton: {
		borderRadius: 10,
		backgroundColor: 'red',
		marginTop: 40
  }
});