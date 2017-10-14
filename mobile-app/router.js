import { StackNavigator, TabNavigator } from "react-navigation";

import Register from "./Register";
import Login from "./Login";
import ForgottenPassword from "./ForgottenPassword";

export const UnauthenticatedApp = StackNavigator({  
  Login: {
    screen: Login,
    navigationOptions: {
      title: "Login"
    }
  },
  Register: {
    screen: Register,
    navigationOptions: {
      title: "Register"
    }
  },
  ForgottenPassword: {
    screen: ForgottenPassword,
    navigationOptions: {
      title: "Forgotten Password"
    }
  },
});

import Record from "./Record";
import RecordingHistory from "./RecordingHistory";

export const AuthenticatedApp = TabNavigator({
  Record: {
    screen: Record,
    navigationOptions: {
      tabBarLabel: "Record"
    }
  },
  RecordingHistory: {
    screen: RecordingHistory,
    navigationOptions: {
      tabBarLabel: "History"
    }
  }
});