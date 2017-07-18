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

export default class Login extends Component {
  _onPressLogin() {
  }
  render() {
    return (
        <View style={styles.container}>
            <FormLabel>Name</FormLabel>
            <FormInput/>
            <FormLabel>Password</FormLabel>
            <FormInput secureTextEntry={true}/>
            <Button 
                title='Login'
                onPress={() => this._onPressLogin()} />
        </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'stretch',
    backgroundColor: '#F5FCFF',
  }
});