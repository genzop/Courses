import React from "react";
import queryString from "query-string";

/* Parametros Url => Para obtener parametros desde la Url, se utiliza la propiedad match. */
/* Query String => Para obtener los query strings se utiliza la propiedad location. Se recomienda utilizar la libreria 'query-string' para mapear el query string en un objeto */
const Posts = ({ match, location }) => {
  const result = queryString.parse(location.search);

  return (
    <div>
      <h1>Posts</h1>
      Year: {match.params.year}, Month: {match.params.month}
    </div>
  );
};

export default Posts;
