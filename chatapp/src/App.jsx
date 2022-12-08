import "./App.css";
import { createBrowserRouter, RouterProvider, Route } from "react-router-dom";
import Login from "./Pages/Login";

const router = createBrowserRouter([
  {
    path: "/login",
    element: <Login></Login>,
  },
  {
    path: "/",
    element: <div>Home</div>,
  },
]);

function App() {
  return <RouterProvider router={router} />;
}

export default App;
