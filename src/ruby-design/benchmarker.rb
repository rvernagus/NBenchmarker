# The basic concept is to time a chunk of code
def benchmark(&proc)
  start_time = Time.now
  proc.call
  end_time = Time.now
  start_time - end_time
end

result = benchmark do
  sleep 1
end
puts result
