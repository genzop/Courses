class ArticlesController < ApplicationController
  # Llamar al metodo set_article antes de ejecutar los metodos show, edit, update y destroy
  before_action :set_article, only: [:show, :edit, :update, :destroy]

  def index
    # Busca todos los articulos
    @articles = Article.all
  end

  def show
  end

  def new
    # Crea un nuevo articulo
    @article = Article.new
  end     

  def create
    # Obtiene las propiedades a traves del metodo article_params
    @article = Article.new(article_params)      
    # Si se puede persisitir el articulo, lo hace
    if @article.save
      # Muestra una notificacion al usuario
      flash[:notice] = "Articulo creado exitosamente"
      # Redirecciona a la ruta article (GET)
      redirect_to article_path(@article)
    # Si no se pasan las validacions o ocurre un error
    else
      # Renderiza la vista new 
      render 'new'
    end
  end

  def edit
  end

  def update
    # Si el articulo pudo ser actualizado
    if @article.update(article_params)
      # Muestra una notificacion al usuario
      flash[:notice] = "Articulo modificado exitosamente"
      # Redirecciona a la lista de articulos
      redirect_to article_path(@article)
    # Si alguna de las validaciones no se cumplio o ocurrio un error
    else
      # Renderiza la vista edit
      render 'edit'
    end
  end

  def destroy
      # Elimina el articulo      
      @article.destroy
      # Muestra una notificacion al usuario
      flash[:notice] = "Articulo eliminado exitosamente"
      # Redirecciona a la lista de articulos
      redirect_to articles_path
  end

  private 
    def set_article
      # Busca al articulo por el id
      @article = Article.find(params[:id])
    end
    def article_params
      # Lee las propiedades title y description del articulo
      params.require(:article).permit(:title, :description)
    end
end