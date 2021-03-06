class Article < ApplicationRecord
  validates :title, presence: true, length: { in: 10..50 }
  validates :description, presence: true, length: { in: 10..300 }
end