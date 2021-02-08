import React, { Component } from 'react';
import {
  AppRegistry,
  StyleSheet,
  Dimensions,
  Text,
  View,
  Image,
  KeyboardAvoidingView
} from 'react-native';
import {
  Container,
  Header,
  Content,
  Form,
  Item,
  Input,
  Button,
  Label,
  Footer,
  Grid,
  Col,
  Row
} from 'native-base';
import firebase from './firebase';

export default class Login extends Component {
  state = {
    username: '',
    password: ''
  };

  _onPressLogin() {
    firebase
      .auth()
      .signInWithEmailAndPassword(this.state.email, this.state.password)
      .then(user => {
        console.log('User successfully logged in', user);
        this.props.navigator.replace({id: "SomeOtherComponent"});
      })
      .catch(err => {
        console.error('User signin error', err);
      });
  }

  render() {
    return (
      <Container>
        <Grid>
          <Row size={45}>
            <View>
              <Image source={require('./img/logo.png')} />
            </View>
          </Row>

          <Row size={45}>
            <View style={styles.loginForm}>
              <Item>
                <Input
                  underline
                  placeholder="E-mail"
                  onChangeText={email => this.setState({ email })}
                />
              </Item>
              <Item last>
                <Input
                  underline
                  placeholder="Password"
                  secureTextEntry={true}
                  onChangeText={password => this.setState({ password })}
                />
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
          </Row>

          <Row size={10}>
            <Col style={{ height: 200, paddingTop: 20 }}>
              <Button
                transparent
                style={{ alignSelf: 'flex-start' }}
                onPress={() => this.props.navigation.navigate('Register')}
              >
                <Text>Create Account</Text>
              </Button>
            </Col>
            <Col style={{ height: 200, paddingTop: 20 }}>
              <Button
                transparent
                style={{ alignSelf: 'flex-end' }}
                onPress={() =>
                  this.props.navigation.navigate('ForgottenPassword')}
              >
                <Text>Forgot Password?</Text>
              </Button>
            </Col>
          </Row>
        </Grid>
      </Container>
    );
  }
}

const deviceHeight = Dimensions.get('window').height;

const styles = {
  container: {
    flex: 1
  },
  shadow: {
    flex: 1,
    width: null,
    height: null
  },
  loginForm: {
    flex: 1,
    paddingLeft: 40,
    paddingRight: 40,
    bottom: 0
  },
  input: {
    marginBottom: 20
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
