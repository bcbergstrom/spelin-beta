import { useState, useEffect } from "react";
import Homescreen from "./components/Homescreen";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Profile from "./components/Profile";
import Login from "./components/Login";
import Games from "./components/Games";
import Reviews from "./components/Reviews";

function App() {
  const [user, setUser]: [string, any]= useState("");
  const [reviewGame, setReviewGame]: [object,any] = useState({});
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
      element:<Games setReviewGame={setReviewGame}/>,
    },
    {
      path: "/login",
      element:<Login setUser={setUser} user={user} />
    },
    {
      path: "/reviews",
      element: <Reviews reviewGame={reviewGame} user={user} />
    }
  ])
  return (
    <>
    <RouterProvider router={router} />
    </>
  );
}

export default App;
