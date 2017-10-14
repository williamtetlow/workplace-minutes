import React, { Component } from 'react';
import {
  AppRegistry
} from 'react-native';
import Login from './Login';
import Record from './Record';
import RecordingHistory from './RecordingHistory';
import ScrollableTabView, {DefaultTabBar} from 'react-native-scrollable-tab-view';
import { UnauthenticatedApp, AuthenticatedApp } from "./router";
import firebase from './firebase';
export default class WorkplaceMobile extends Component {

  constructor() {
    super();
    this.unsubscribe = null;
  }

  componentDidMount() {
    this.unsubscribe = firebase.auth().onAuthStateChanged((user) => {
      if (user) {
        this.loggedIn = true;
      } else {
        this.loggedIn = false;
      }
    });
  }

  componentWillUnmount() {
    if (this.unsubscribe) {
      this.unsubscribe();
    }
  }

  render() {
    const isLoggedIn = firebase.auth().authenticated;
    if (isLoggedIn) {
      return (<AuthenticatedApp/>);
    }
    return (<UnauthenticatedApp/>);
  }
}

AppRegistry.registerComponent('WorkplaceMobile', () => WorkplaceMobile);
