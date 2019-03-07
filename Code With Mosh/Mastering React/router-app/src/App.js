import React, { Component } from "react";
import NavBar from "./components/navbar";
import { Route, Switch, Redirect } from "react-router-dom";
import Products from "./components/products";
import Posts from "./components/posts";
import Home from "./components/home";
import Dashboard from "./components/admin/dashboard";
import ProductDetails from "./components/productDetails";
import NotFound from "./components/notFound";
import "./App.css";

class App extends Component {
  render() {
    return (
      <div>
        <NavBar />
        <div className="content">
          {/* Se configuran las rutas para los diferentes componentes desde las mas especificas a las mas genericas */}
          <Switch>
            {/* Ruta con parametros obligatorios */}
            <Route path="/products/:id" component={ProductDetails} />
            {/* La prop render permite pasar props al componente, pero es necesario pasarle las props de esta manera */}
            <Route
              path="/products"
              render={props => <Products sortBy="newest" {...props} />}
            />
            {/* Ruta con parametros opcionales (Evitar utilizar parametros opcionales) */}
            <Route path="/posts/:year?/:month?" component={Posts} />
            <Route path="/admin" component={Dashboard} />
            {/* Redirecciona desde /messages a /posts */}
            <Redirect from="/messages" to="/posts" />
            <Route path="/not-found" component={NotFound} />
            <Route path="/" exact component={Home} />
            {/* En caso de no encontrar ninguna ruta correcta, redireccionar a /not-found*/}
            <Redirect to="/not-found" />
          </Switch>
        </div>
      </div>
    );
  }
}

export default App;
