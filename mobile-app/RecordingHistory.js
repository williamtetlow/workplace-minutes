import React, { 
	Component 
} from 'react';
import {
  StyleSheet,
  Text,
  View,
  Image,
	ActivityIndicator
} from 'react-native';
import { 
Tabs, Tab, Icon, List, ListItem
} from 'react-native-elements'
import firebase from './firebase';
import Record from './Record';

export default class RecordingHistory extends Component {
  constructor() {
    super();
    this.ref = null;
  }

  state = {
    recordings: []
  };

  componentDidMount() {
    const self = this;
    this.ref = firebase.database().ref('recordings');
    this.ref.on('value', function(snapshot) {
      console.log(snapshot);
      var items = [];
      snapshot.forEach((child) => {
        items.push({
          description: child.val().description,
          _key: child.key
        });
      });

      self.setState({ recordings: items });
    });
  }

  componentWillUnmount() {
    if (this.ref) {
      this.ref.off('value');
    }
  }

  render() {
    return (    
    <List>
        {
    this.state.recordings.map((l, i) => (
      <ListItem
        title={l.description}
      />
    ))
  }
      <ListItem
        title='My First Meeting'
        subtitle={
          <View style={styles.subtitleView}>
            <Image style={styles.ratingImage}/>
            <Text style={styles.ratingText}>5 months ago</Text>
          </View>
        }
      />
      <ListItem
        title='My Second Meeting'
        subtitle={
          <View style={styles.subtitleView}>
            <Image style={styles.ratingImage}/>
            <Text style={styles.ratingText}>5 months ago</Text>
          </View>
        }
      />
      <ListItem
        title='My Third Meeting'
        subtitle={
          <View style={styles.subtitleView}>
            <Image style={styles.ratingImage}/>
            <Text style={styles.ratingText}>5 months ago</Text>
          </View>
        }
      />
    </List>);
  }
}
const styles = StyleSheet.create({
  subtitleView: {
    flexDirection: 'row',
    paddingLeft: 10,
    paddingTop: 5
  },
  ratingImage: {
    height: 19.21,
    width: 100
  },
  ratingText: {
    paddingLeft: 10,
    color: 'grey'
  }
})