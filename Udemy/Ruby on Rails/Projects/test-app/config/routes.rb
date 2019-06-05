Rails.application.routes.draw do
  resources :articles
  get 'welcome/home', to: 'welcome#home'
  get 'welcome/about', to: 'welcome#about'
end
