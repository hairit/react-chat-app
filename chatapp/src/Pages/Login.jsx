import React, { Component } from "react";

export default class Login extends Component {
  constructor(props) {
    super();
    this.state = {
      url: "https://localhost:44385/api/ChatUser",
    };
  }

  submitLogin = (e) => {
    e.preventDefault();
    fetch(this.state.url + "/marcus/tuonghai")
      .then((response) => response.json())
      .then((data) => console.log(data));
  };

  render() {
    return (
      <form className="login-page" onSubmit={this.submitLogin}>
        <input type={"text"} placeholder="Your username" />
        <input type={"password"} placeholder="Your password" />
        <button type="submit">Login</button>
      </form>
    );
  }
}
