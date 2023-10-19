namespace Zuri_Portfolio_Explore.Utilities
{
	public static class Shared
	{
		private readonly static HttpContextAccessor _httpContextAccessor = new();

		public static string ProfileUrl(Guid userId)
		{
			var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/api/explore/getPortfolio/{userId.ToString()}";
			//var baseUrl = $"https://zuriportfolio-frontend-pw1h-1fxrnqen1-zuri-frontend.vercel.app/portfolio/{userId}";
			return baseUrl;
		}
	}

	public static class General
	{

		public static List<string> images = new List<string>()
		{
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697122998/prince-akachi-i2hoD-C2RUA-unsplash_dpqhkb.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697122999/philip-martin-5aGUyCW_PJw-unsplash_g6nch9.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697122999/prince-akachi-J1OScm_uHUQ-unsplash_ebtbrj.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697122999/stephanie-liverani-Zz5LQe-VSMY-unsplash_d3rtu4.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697122999/joseph-gonzalez-iFgRcqHznqg-unsplash_txb54q.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697122999/rachel-mcdermott-0fN7Fxv1eWA-unsplash_ipqxts.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697122999/good-faces-xmSWVeGEnJw-unsplash_mimcjl.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697122998/prince-akachi-4Yv84VgQkRM-unsplash_pmww0i.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697122998/omid-armin-HtQLD6HOS94-unsplash_vqbmpl.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697122998/aiony-haust-3TLl_97HNJo-unsplash_ihc6tw.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697122997/pavel-anoshin-d0peGya6R5Y-unsplash_ak3cs6.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697124857/brooke-cagle-NoRsyXmHGpI-unsplash_apquoq.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697124857/rayan-mill-AGlO2jlVE4c-unsplash_oni0su.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697124858/meritt-thomas-aoQ4DYZLE_E-unsplash_1_wiuxqw.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697124857/austin-distel-7uoMmzPd2JA-unsplash_nvfsqw.jpg",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697390039/Truncated_avatar_utukwm.png",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697390039/Truncated_avatar-1_jyzutk.png",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697390039/Truncated_avatar-11_kiymsd.png",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697390039/Truncated_avatar-9_ozfm9c.png",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697390039/Truncated_avatar-8_zl8cdo.png",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697390039/Truncated_avatar-10_dhcqko.png",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697390039/Truncated_avatar-4_jgiohm.png",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697390039/Truncated_avatar-7_vkf85v.png",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697390039/Truncated_avatar-6_pfvu3x.png",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697390038/Truncated_avatar-2_rkwori.png",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697390038/Truncated_avatar-5_c66buu.png",
			"https://res.cloudinary.com/dw5cv0yz0/image/upload/v1697390038/Truncated_avatar-3_sbjsrb.png"
		};

		public static List<string> webDeveloperSkills = new List<string>
		{
			"HTML/CSS",
			"JavaScript",
			"Responsive Design",
			"Version Control/Git",
			"Frontend Frameworks",
			"Backend Frameworks",
			"RESTful APIs",
			"Database Management",
			"Security Best Practices",
			"Testing/Debugging"
		};
		public static List<string> embededIot = new List<string>
		{
			"HTML/CSS",
			"JavaScript",
			"Responsive Design",
			"Version Control/Git",
			"Frontend Frameworks",
			"Backend Frameworks",
			"RESTful APIs",
			"Database Management",
			"Security Best Practices",
			"Testing/Debugging"
		};

		public static List<string> graphicsDesignerSkills = new List<string>
		{
			"Adobe Creative Suite",
			"Typography",
			"Color Theory",
			"Visual Communication",
			"UX/UI Design",
			"Digital Illustration",
			"Print Design",
			"Web Design",
			"Storyboarding",
			"Attention to Detail"
		};

		public static List<string> artificialIntelligenceSkills = new List<string>
		{
			"Machine Learning Algorithms",
			"Deep Learning (TensorFlow, PyTorch)",
			"Natural Language Processing (NLP)",
			"Computer Vision",
			"Reinforcement Learning",
			"Data Mining",
			"AI Ethics"
		};

		public static List<string> dataScienceSkills = new List<string>
		{
			"Statistical Analysis",
			"Data Visualization",
			"Data Cleaning and Preprocessing",
			"Programming (Python, R)",
			"Machine Learning",
			"Big Data Technologies (Hadoop, Spark)",
			"Database Querying (SQL)",
		};

		public static List<string> mobileAppDevelopmentSkills = new List<string>
		{
			"Programming (Java, Swift, Kotlin)",
			"Mobile UI Design",
			"Cross-Platform Development (React Native, Xamarin)",
			"API Integration",
			"Database Management (SQLite, Realm)",
			"Performance Optimization",
			"User Experience (UX) Design"
		};

		public static List<string> cybersecuritySkills = new List<string>
		{
			"Network Security",
			"Web Security (OWASP Top 10)",
			"Cryptography",
			"Incident Response",
			"Security Compliance",
			"Penetration Testing",
			"Security Awareness Training"
		};

		public static List<string> blockchainDevelopmentSkills = new List<string>
		{
			"Blockchain Concepts",
			"Smart Contracts (Solidity)",
			"Distributed Ledger Technology",
			"Cryptocurrency Protocols",
			"Consensus Algorithms",
			"Blockchain Security",
			"Decentralized Applications (DApps)"
		};
	}
}
