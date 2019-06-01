users = [
  { username: "mashrur", password: "password1" },
  { username: "jack", password: "password2" },
  { username: "arya", password: "password3" },
  { username: "jonshow", password: "password4" },
  { username: "heisenberg", password: "password5" },
]

def auth_user(username, password, list_of_users)
  list_of_users.each do |user_record|
    if user_record[:username] == username && user_record[:password] == password
      return user_record
    end
  end    
  return "Credentials were not correct"
end

puts "Welcome to the authenticator"
60.times { print "-" }
puts
puts "This program will take input from the user and compare password"
puts "If password is correct, you will get back the user object"
puts
attemps = 1
while attemps < 4 do
  print "Username: "
  username = gets.chomp
  print "Password: "
  password = gets.chomp    
  puts auth_user(username, password, users)        
  puts "Press n to quit or any other key to continue:"    
  input = gets.chomp.downcase
  break if input == "n"
  attemps += 1
end
puts "You've exceeded the number of attempts" if attemps == 4 