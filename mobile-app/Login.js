import React, { Component } from 'react';
import {
  AppRegistry,
  StyleSheet,
  Dimensions,
  Text,
  View
} from 'react-native';
import { Image, Container, Header, Content, Form, Item, Input, Button, Label, Footer, Grid, Col } from 'native-base';

export default class Login extends Component {
  _onPressLogin() {
  }
  render() {
    return (
      <Container>
        <View style={styles.container}>
          <Content>
            <View style={styles.loginForm}>
              <Item>
                <Input
                  underline
                  placeholder="Username" />
              </Item>
              <Item last>
                <Input
                  underline
                  placeholder="Password"
                  secureTextEntry={true} />
              </Item>
              <Button
                block
                primary
                style={styles.btn}
                onPress={() => this._onPressLogin()}
              >
                <Text style={styles.btnText}>Login</Text>
              </Button>
            </View>
          </Content>
          <Footer style={styles.footer}>
            <Grid>
              <Col style={{ height: 200 }}>
                <Button transparent style={{ alignSelf: 'flex-start' }}>
                  <Text>Create Account</Text>
                </Button></Col>
              <Col style={{ height: 200 }}>
                <Button transparent style={{ alignSelf: 'flex-end' }}>
                  <Text>Forgot Password?</Text>
                </Button></Col>
            </Grid>
          </Footer>
        </View>
      </Container>
    );
  }
}

const deviceHeight = Dimensions.get('window').height;

const styles = {
  container: {
    position: 'absolute',
    top: 0,
    bottom: 0,
    left: 0,
    right: 0,
    backgroundColor: '#FBFAFA',
  },
  shadow: {
    flex: 1,
    width: null,
    height: null,
  },
  loginForm: {
    flex: 1,
    marginTop: deviceHeight / 3,
    paddingTop: 20,
    paddingLeft: 40,
    paddingRight: 40,
    paddingBottom: 30,
    bottom: 0,
  },
  input: {
    marginBottom: 20,
  },
  btn: {
    marginTop: 40
  },
  btnText: {
    color: 'white',
    fontSize: 20
  },
  footer: {
    backgroundColor: '#FBFAFA'
  }
};
