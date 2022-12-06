import { useState } from "react";
import "./App.css";
import styles from "@chatscope/chat-ui-kit-styles/dist/default/styles.min.css";
import {
  MainContainer,
  ChatContainer,
  MessageList,
  Message,
  MessageInput,
} from "@chatscope/chat-ui-kit-react";

function App() {
  return (
    <MainContainer>
      <ChatContainer>
        <MessageList>
          <Message
            model={{
              message: "Hello my friend",
              sentTime: "just now",
              sender: "Joe",
            }}
          />
          <Message
            model={{
              message: "Hello my friend",
              sentTime: "just now",
              sender: "Joe",
            }}
          />
        </MessageList>
        <MessageInput placeholder="Type message here" />
      </ChatContainer>
    </MainContainer>
  );
}

export default App;
