import React, { Component } from 'react';
import {
  AppRegistry
} from 'react-native';
import LoginForm from './LoginForm';

export default class WorkplaceMobile extends Component {
  render() {
    return (
      <LoginForm/>
    );
  }
}

AppRegistry.registerComponent('WorkplaceMobile', () => WorkplaceMobile);
