def add(num1, num2)
  num1.to_f + num2.to_f
end 

def subtract(num1, num2)
  num1.to_f - num2.to_f
end

def multiply(num1, num2)
  num1.to_f * num2.to_f
end

def divide(num1, num2)
  num1.to_f / num2.to_f
end

def mod(num1, num2)
  num1.to_f % num2.to_f
end

puts "Simple calculator"
25.times { print "-" }
puts
puts "Enter the first number"
num1 = gets.chomp
puts "Enter the second number"
num2 = gets.chomp
puts "Select the operation"
puts "1.Addition 2.Subtraction 3.Multipication 4.Division 5.Mod"
operation = gets.chomp
100.times { print "-" }
puts

if operation.to_i == 1
  puts "You've selected addition"
  puts "The first number plus the second number is #{add(num1, num2)}"
elsif operation.to_i == 2
  puts "You've selected subtraction"
  puts "The first number minus the second number is #{subtract(num1, num2)}"
elsif operation.to_i == 3
  puts "You've selected multiplication"
  puts "The first number multiplied by the second number is #{multiply(num1, num2)}"
elsif operation.to_i == 4
  puts "You've selected division"
  puts "The first number divided by the second number is #{divide(num1, num2)}"
elsif operation.to_i == 5
  puts "You've selected mod"
  puts "The first number mod by the second number is #{mod(num1, num2)}"    
else
  puts "Invalid input"
end