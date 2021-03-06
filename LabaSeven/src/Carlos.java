public class Carlos {
	public static double getPi(int numThrows){
		int threads = 8;
        int iterations = 1000000000;
		int inCircle= 0;
		for(int i= 0;i < numThrows;i++){
			double randX= (Math.random() * 2) - 1;
			double randY= (Math.random() * 2) - 1;
			double dist= Math.sqrt(randX * randX + randY * randY);
			if(dist < 1){
				inCircle++;
			}
		}
		return (4.0 * inCircle) / numThrows;
	}
	public static void main(String[] args) {
		long timerStart = System.nanoTime();
		System.out.println("PI is " + getPi(1000000000));
		System.out.println("THREADS 8");
		System.out.println("ITERATIONS 1,000,000,000");
		long timerEnd = System.nanoTime();
        long totalTime = (timerEnd - timerStart);
		System.out.println("TIME: " + totalTime/1000000);
	}
}
