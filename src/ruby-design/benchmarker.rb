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

class BenchmarkResult
  attr_accessor :elapsed_time, :number_of_iterations

  def initialize
    @elapsed_time = 0
    @number_of_iterations = 0
  end

  def to_s
    "#<BenchmarkResult @elapsed_time=#{@elapsed_time}, @number_of_iterations=#{@number_of_iterations}>"
  end
end


# The basic concept is to time a chunk of code
class Benchmarker
  def benchmark(trial)
    trial.before_benchmark

    result = BenchmarkResult.new
    while continue_benchmark?(result)
      trial.before_benchmark_loop
      start_time = Time.now
      trial.benchmark_loop
      end_time = Time.now
      result.elapsed_time += end_time - start_time
      result.number_of_iterations += 1
      trial.after_benchmark_loop
    end

    trial.after_benchmark

    result
  end

  def continue_benchmark?
    false
  end
end

class TimedBenchmarker < Benchmarker
  def initialize(number_of_seconds)
    @number_of_seconds = number_of_seconds
  end

  def continue_benchmark?(result)
    result.elapsed_time < @number_of_seconds
  end
end

class IterationBenchmarker < Benchmarker
  def initialize(number_of_iterations)
    @number_of_iterations = number_of_iterations
  end

  def continue_benchmark?(result)
    result.number_of_iterations < @number_of_iterations
  end
end

puts "----------------"
benchmarker1 = TimedBenchmarker.new(5)
result = benchmarker1.benchmark(MyTrial.new)
puts result
benchmarker2 = IterationBenchmarker.new(6)
result = benchmarker2.benchmark(MyTrial.new)
puts result
