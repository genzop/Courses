import React from "react";
import { Link } from "react-router-dom";

const NavBar = () => {
  return (
    <ul>
      <li>
        {/* El componente Link permite redireccionar sin necesidad de llamar al server */}
        <Link to="/">Home</Link>
      </li>
      <li>
        <Link to="/products">Products</Link>
      </li>
      <li>
        <Link to="/posts/2018/06">Posts</Link>
      </li>
      <li>
        <Link to="/admin">Admin</Link>
      </li>
    </ul>
  );
};

export default NavBar;
