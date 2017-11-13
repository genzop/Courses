var AppointmentForm = Backbone.View.extend({
  template: _.template('<form><input name="title" type="text" /><input name="name" type="text" /></form>'),
  render: function(){
    this.$el.html(this.template(this.model.attributes));
    return this;
  }
});