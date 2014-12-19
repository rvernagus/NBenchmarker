class Trial
  def before_benchmark; end
  def before_benchmark_loop; end
  def benchmark_loop; end
  def after_benchmark_loop; end
  def after_benchmark; end
end

class MyTrial < Trial
  def before_benchmark
    puts "before_benchmark"
  end
  def before_benchmark_loop
    puts "  before_benchmark_loop"
  end
  def benchmark_loop
    puts "    benchmark_loop"
    sleep 1
  end
  def after_benchmark_loop
    puts "  after_benchmark_loop"
  end
  def after_benchmark
    puts "after_benchmark"
  end
end

# The basic concept is to time a chunk of code
class Benchmarker
  def benchmark(trial)
    trial.before_benchmark

    result = 0
    0.upto(9) do
      trial.before_benchmark_loop
      start_time = Time.now
      trial.benchmark_loop
      end_time = Time.now
      result += start_time - end_time
      trial.after_benchmark_loop
    end

    trial.after_benchmark

    result
  end
end

puts "----------------"
benchmarker = Benchmarker.new
result = benchmarker.benchmark(MyTrial.new)
puts result
