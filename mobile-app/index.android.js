import React, { Component } from 'react';
import {
  AppRegistry
} from 'react-native';
import {
  StackNavigator,
} from 'react-navigation';
import Login from './Login';
import Record from './Record';

export default class WorkplaceMobile extends Component {
  render() {
    let activeView = <Login/>;
    const isLoggedIn = true;//this.state.isLoggedIn;
    if (isLoggedIn) {
      activeView = <Record/>;
    }
    return (activeView);
  }
}

AppRegistry.registerComponent('WorkplaceMobile', () => WorkplaceMobile);
