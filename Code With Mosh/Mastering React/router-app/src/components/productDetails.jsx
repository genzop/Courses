import React, { Component } from "react";

class ProductDetails extends Component {
  handleSave = () => {
    // Redirecciona a "/products" (push => permite navegar para atras, replace => no permite navegar para atras)
    this.props.history.push("/products");
  };

  render() {
    return (
      <div>
        {/* Obtiene el id de la url*/}
        <h1>Product Details - {this.props.match.params.id} </h1>
        <button onClick={this.handleSave}>Save</button>
      </div>
    );
  }
}

export default ProductDetails;
