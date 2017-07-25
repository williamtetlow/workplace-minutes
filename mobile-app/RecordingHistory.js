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

  render() {
    return (    
    <List>
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