import React, { Component } from 'react';
import {
  AppRegistry
} from 'react-native';
import Login from './Login';
import Record from './Record';
import RecordingHistory from './RecordingHistory';
import ScrollableTabView, {DefaultTabBar } from 'react-native-scrollable-tab-view';

export default class WorkplaceMobile extends Component {
  render() {
    const isLoggedIn = true;//this.state.isLoggedIn;
    if (isLoggedIn) {
      return (
        <ScrollableTabView
          renderTabBar={() => <DefaultTabBar />}>
          <Record tabLabel='Record'/>
          <RecordingHistory tabLabel='History'/>
        </ScrollableTabView>
      );
    }
    return (<Login/>);
  }
}

AppRegistry.registerComponent('WorkplaceMobile', () => WorkplaceMobile);
