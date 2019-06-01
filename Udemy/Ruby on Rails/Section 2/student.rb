require_relative 'Encrypt'

class Student
  # Incluye el modulo Encrypt, haciendolo disponible dentro de la clase
  include Encrypt
    
  # Permite obtener y setear estas propiedades
  attr_accessor :first_name, :last_name, :email, :username, :password
 
  # Propiedades
  @first_name
  @last_name
  @email
  @username
  @password

  # Constructor
  def initialize(firstname, lastname, username, email, password)
    @first_name = firstname
    @last_name = lastname
    @email = email
    @username = username
    @password = password
  end

  def to_s
    "First name: #{@first_name}, Last name: #{@last_name}, Username: #{@username}, Email: #{@email}"
  end
end

enzo = Student.new("Enzo", "Panettieri", "genzop", "enzo@email.com", "password1")
juan = Student.new("Juan", "Perez", "jperez", "juan@email.com", "password2")

hashed_password = enzo.create_hash_digest(enzo.password)
puts hashed_password