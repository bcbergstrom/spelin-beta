import { useState, useEffect } from "react";
import Homescreen from "./components/Homescreen";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Profile from "./components/Profile";
import Login from "./components/Login";
import Games from "./components/Games";

function App() {
  const [user, setUser]: [string, any]= useState("");
  const router = createBrowserRouter([
    {
      path: "/",
      element: <Homescreen />,
    },

    {
      path: "/profile",
      element: <Profile />,
    },
    {
      path: "/games",
      element:<Games/>,
    },
    {
      path: "/login",
      element:<Login setUser={setUser} user={user} />
    },
  ])
  return (
    <>
    <RouterProvider router={router} />
    </>
  );
}

export default App;
