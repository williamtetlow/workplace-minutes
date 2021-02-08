import React, { Component } from 'react';
import {
  AppRegistry,
  StyleSheet,
  Dimensions,
  Text,
  View,
  KeyboardAvoidingView
} from 'react-native';
import { Image, Container, Header, Content, Form, Item, Input, Button, Label, Footer, Grid, Col, Row } from 'native-base';

export default class ForgottenPassword extends Component {
  _onPressLogin() {
  }
  render() {
    return (
      <Container>

        <Grid>
          <Row>
            <View style={styles.loginForm}>
              <Item>
                <Input
                  underline
                  placeholder="E-mail" />
              </Item>
              <Button
                block
                primary
                style={styles.btn}
                onPress={() => this._onPressLogin()}
              >
                <Text style={styles.btnText}>Reset Password</Text>
              </Button>
            </View>
          </Row>
        </Grid>
      </Container>
    );
  }
}

const deviceHeight = Dimensions.get('window').height;

const styles = {
  container: {
    flex: 1,
  },
  shadow: {
    flex: 1,
    width: null,
    height: null,
  },
  loginForm: {
    flex: 1,
    paddingLeft: 40,
    paddingRight: 40,
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
