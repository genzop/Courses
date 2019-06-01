require_relative 'Encrypt'

users = [
  { username: "enzo", password: "password1" },
  { username: "jack", password: "password2" },
  { username: "arya", password: "password3" },
  { username: "jonshow", password: "password4" },
  { username: "heisenberg", password: "password5" },
]

hashed_users =  Encrypt.create_secure_users(users)
puts hashed_users   