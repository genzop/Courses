import React from "react";

const Like = props => {
  let classes = "fa fa-heart";
  if (!props.movie.liked) {
    classes += "-o";
  }

  return (
    <i
      className={classes}
      style={{ cursor: "pointer" }}
      onClick={() => props.onLike(props.movie)}
    />
  );
};

export default Like;
