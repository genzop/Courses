# Exporta todos los metodos en un modulo llamado Encrypt
module Encrypt
  # Importa la gem bcrypt
  require 'bcrypt'
  puts "Module Encrypt activated"

  def create_hash_digest(password)
    BCrypt::Password.create(password)
  end

  def verify_hash_digest(password)
    BCrypt::Password.new(password)
  end

  def create_secure_users(list_of_users)
    list_of_users.each do |user|
      user[:password] = create_hash_digest(user[:password])
    end
    list_of_users
  end

  def authenticate_user(username, password, list_of_users)
    list_of_users.each do |user|
      if(user[:username] == username && verify_hash_digest(user[:password]) == password)
        return user
      end        
    end
    "Credentials were not correct"
  end
end