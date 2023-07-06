<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="HMIT.home" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>HM Institute Of Technology</title>
    <link rel="stylesheet" href="CSS/home.css">
    <link rel="stylesheet" href="CSS/background.css">
    <link rel="stylesheet" href="CSS/navigation.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body>
    <form runat="server">
        <section class="header">
            <nav>
                <a href="home.html">
                    <img src="CSS/Resources/Icons/logo.png"></a>
                <div class="nav-links" id="navLinks">
                    <i class="fa fa-times" onclick="hideMenu()"></i>
                    <ul>
                        <li><a href="login.aspx">LOGIN</a></li>
                        <li><a href="about.aspx" target="_blank">ABOUT</a></li>
                        <li><a href="#course">COURSE</a></li>
                        <li><a href="#campus">CAMPUS</a></li>
                        <li><a href="#faculty">FACULTY</a></li>
                        <li><a href="#facility">FACILITY</a></li>
                        <li><a href="notice.aspx">NOTICE</a></li>
                        <li><a href="https://www.google.com/maps/place/Khulna+University+of+Engineering+%26+Technology/@22.9005524,89.4997816,17z/data=!3m1!4b1!4m6!3m5!1s0x39ff9bda1d0ff6e5:0x123a926908efcd0c!8m2!3d22.9005524!4d89.5023565!16zL20vMGRfMl9x" target="_blank">LOCATION</a></li>
                        <li><a href="#contact">CONTACT</a></li>
                    </ul>
                </div>
                <i class="fa fa-bars" id="menu" onclick="showMenu()"></i>
            </nav>
            <div class="text-box">
                <h1 style="font-size: 80px;">HM Institute Of Technology</h1>
                <p>Provides All The Qualities Requires To Be A Successful Engineer.<br>
                    Chase Your Dreams, Success Will Follow You.</p>
                <a href="#course" class="hero-btn">Visit Us To Know More</a>
            </div>
        </section>

        <section class="course" id="course">
            <h1>Courses We Offer</h1>
            <div class="row">
                <div class="course-col">
                    <h3>Graduation</h3>
                    <p>Degrees are awarded by the Corporation of the Institute in September, February, and May upon recommendation of the Faculty. Favorable faculty action is based upon approval by the Committee on Academic Performance or the Committee on Graduate Programs on recommendations from departmental committees<br>
                        Students must submit an online SB degree application or advanced degree application by the deadline for each regular term or the summer session, as established in the academic calendar.</p>
                </div>
                <div class="course-col">
                    <h3>Post-Graduation</h3>
                    <p>The goals of the postgraduate programmes are: The development of scientific and engineering manpower of the highest quality, to cater to the needs of industry, R & D organizations and educational institutions, a broad grasp of the fundamental principles of the sciences and scientific methods, a deep understanding of the area of specialization, an innovative ability to solve new problems, and a capacity to learn continually and interact with multidisciplinary groups.</p>
                </div>
                <div class="course-col">
                    <h3>PhD</h3>
                    <p>We are looking for bright and dedicated young scholars interested in research to join us as Ph.D. scholars.<br>
                        Prospective students satisfying the eligibility criteria are encouraged to acquaint themselves with the research areas of our faculty members for suitable match of interest. HMIT also offers a Start Early Ph.D. Fellowship with additional financial support for exceptionally qualified undergraduate students from select colleges wishing to start on a direct Ph.D. programme after B.Tech.</p>
                </div>
            </div>
        </section>

        <section class="campus" id="campus">
            <h1>Our Global Campus</h1>
            <div class="row">
                <div class="campus-col">
                    <img src="CSS/Resources/Backgrounds/crop (1).jpg">
                    <div class="layer">
                        <h3>LONDON</h3>
                    </div>
                </div>
                <div class="campus-col">
                    <img src="CSS/Resources/Backgrounds/crop (2).jpg">
                    <div class="layer">
                        <h3>New Work</h3>
                    </div>
                </div>
                <div class="campus-col">
                    <img src="CSS/Resources/Backgrounds/crop (3).jpg">
                    <div class="layer">
                        <h3>Washington</h3>
                    </div>
                </div>
            </div>
        </section>

        <section class="faculty" id="faculty">
            <h1>Our Faculties</h1>
            <div class="row">
                <div class="faculty-col">
                    <a href="#popup-civil" id="popup-link">
                        <h3 class="department-name">Civil Engineering (CE)</h3>
                    </a>
                    <div id="popup-civil" class="overlay">
                        <div class="popup">
                            <h2 style="margin-bottom: 8px;">Faculty Of Civil
                                Engineering</h2>
                            <a class="close" href="#">&times;</a>
                            <div class="content">
                                <div class="slider">
                                    <div class="info">
                                        <p style="margin-top: 10px;">The Faculty of Civil Engineering, HM Institute of Technology offers both the undergraduate and post-graduates degrees maintaining its long-standing reputation for excellence in education and research, both nationally and internationally. Presently, it comprises seven departments:(i) Civil Engineering, (ii) Urban and Regional Planning, (iii) Building Engineering & Construction Management, (iv) Mathematics, (v) Chemistry,(vi) Physics and (vii) Humanities. Among these seven departments, Civil Engineering offers B.Sc. Eng. Degree since 1974, M.Sc. Eng. and Ph.D. since 1994 while Urban & Regional Planning offers only BURP since 2010 and Building Engineering & Construction Management offers B.Sc. Eng. since 2013. Mathematics, Chemistry and Physics offers M.Phill and Ph.D. since 2000, while Humanities does not offer any degree. The undergraduate and postgraduate curriculum have a long tradition of providing a firm ground in engineering fundamentals, design and innovative knowledge. Our faculty members are rigorously trained experienced in the respective fields. They take teaching to heart as well as conduct advanced research. With all the existing accomplishments, faculty of civil engineering has full confidence to provide international standard degrees to face the new and inherent challenges both in home and abroad.</p>
                                        <main class="table">
                                            <section class="table_body">
                                                <table>
                                                    <thead>
                                                        <tr>
                                                            <th>Sl. No.</th>
                                                            <th>Department Name</th>
                                                            <th>Total Seats</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>1</td>
                                                            <td>Department of Civil Engineering</td>
                                                            <td>120</td>
                                                        </tr>
                                                        <tr>
                                                            <td>2</td>
                                                            <td>Department of Urban and Regional Planning</td>
                                                            <td>40</td>
                                                        </tr>
                                                        <tr>
                                                            <td>3</td>
                                                            <td>Department of Building Engineering & Construction Management</td>
                                                            <td>30</td>
                                                        </tr>
                                                        <tr>
                                                            <td>4</td>
                                                            <td>Department of Architecture</td>
                                                            <td>40</td>
                                                        </tr>
                                                        <tr>
                                                            <td>5</td>
                                                            <td>Department of Mathematics</td>
                                                            <td>N/A</td>
                                                        </tr>
                                                        <tr>
                                                            <td>6</td>
                                                            <td>Department of Chemistry</td>
                                                            <td>N/A</td>
                                                        </tr>
                                                        <tr>
                                                            <td>7</td>
                                                            <td>Department of Physics</td>
                                                            <td>N/A</td>
                                                        </tr>
                                                        <tr>
                                                            <td>8</td>
                                                            <td>Department of Humanities</td>
                                                            <td>N/A</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </section>
                                        </main>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="faculty-col">
                    <a href="#popup-eee" id="popup-link">
                        <h3 class="department-name">Electrical and Electronic Engineering (EEE)</h3>
                    </a>
                    <div id="popup-eee" class="overlay">
                        <div class="popup">
                            <h2 style="margin-bottom: 8px;">Faculty Of Electrical and Electronic Engineering</h2>
                            <a class="close" href="#">&times;</a>
                            <div class="content">
                                <div class="slider">
                                    <div class="info">
                                        <p style="margin-top: 10px;">Faculty of Electrical and Electronic Engineering (EEE) at HM Institute of Technology (HMIT) offers unique opportunities for education, research and innovation to meet the increasing demand for highly educated engineering professionals. Now, the EEE faculty has grown beyond expectations and is consistently ranked among the top Engineering faculties of Bangladesh. Since its inception, the EEE faculty at HMIT has been active in recruiting outstanding new faculty members to support its teaching and research activities. Every year, a number of our faculty members gets higher education and short-term scientific and research training in well reputed International universities. Our highly qualified faculty members have tremendous potential to change the traditional way of thinking about engineering education, pedagogy and research excellence. Our faculty members are conducting research in the core areas of electrical engineering, electronics, computer engineering, communication engineering and biomedical engineering, and laudable outcomes are often appraised at home and abroad. The faculty fosters future scientists and engineers and aims at developing not only the ability in students to live flexibly and aggressively in our rapidly changing society, but also at producing scientists and engineers with fundamental academic skills to advance our modern way of life. It is our mission to develop professionals with a global perspective and who take an active role in international progress. Our students already proved their merits and endeavors in home and abroad by securing the top positions in their respective fields and we hope to offer furthering its continuation. So as you browse our new web site, I hope you will discover new information, ideas, and inspiration. Scrolling through these pages you will learn about our exceptional degree and executive education programs, our distinguished faculty, and our achievements.</p>
                                        <main class="table">
                                            <section class="table_body">
                                                <table>
                                                    <thead>
                                                        <tr>
                                                            <th>Sl. No.</th>
                                                            <th>Department Name</th>
                                                            <th>Total Seats</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>1</td>
                                                            <td>Department of Electrical and Electronic Engineering</td>
                                                            <td>120</td>
                                                        </tr>
                                                        <tr>
                                                            <td>2</td>
                                                            <td>Department of Computer Science & Engineering</td>
                                                            <td>120</td>
                                                        </tr>
                                                        <tr>
                                                            <td>3</td>
                                                            <td>Department of Electronics and Communication Engineering</td>
                                                            <td>120</td>
                                                        </tr>
                                                        <tr>
                                                            <td>4</td>
                                                            <td>Department of Biomedical Engineering</td>
                                                            <td>30</td>
                                                        </tr>
                                                        <tr>
                                                            <td>5</td>
                                                            <td>Department of Material Science and Engineering</td>
                                                            <td>60</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </section>
                                        </main>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="faculty-col">
                    <a href="#popup-mecha" id="popup-link">
                        <h3 class="department-name">Mechanical Engineering (ME)</h3>
                    </a>
                    <div id="popup-mecha" class="overlay">
                        <div class="popup">
                            <h2 style="margin-bottom: 8px;">Faculty Of Mechanical Engineering</h2>
                            <a class="close" href="#">&times;</a>
                            <div class="content">
                                <div class="slider">
                                    <div class="info">
                                        <p style="margin-top: 10px;">The academic departments of the university offer degree programs in different engineering, and science disciplines. All the departments except Dept. of Humanities have the postgraduate programs, while the departments of Civil Engineering, Electrical and Electronic Engineering,Mechanical Engineering, Computer Science and Engineering, Electronics Communication Engineering , Industrial Engineering and Management offer undergraduate degree programs.</p>
                                        <main class="table">
                                            <section class="table_body">
                                                <table>
                                                    <thead>
                                                        <tr>
                                                            <th>Sl. No.</th>
                                                            <th>Department Name</th>
                                                            <th>Total Seats</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>1</td>
                                                            <td>Department of Mechanical Engineering</td>
                                                            <td>120</td>
                                                        </tr>
                                                        <tr>
                                                            <td>2</td>
                                                            <td>Department of Industrial Engineering and Management</td>
                                                            <td>60</td>
                                                        </tr>
                                                        <tr>
                                                            <td>3</td>
                                                            <td>Department of Leather Engineering</td>
                                                            <td>30</td>
                                                        </tr>
                                                        <tr>
                                                            <td>4</td>
                                                            <td>Department of Textile Engineering</td>
                                                            <td>60</td>
                                                        </tr>
                                                        <tr>
                                                            <td>5</td>
                                                            <td>Department of Energy  Science and Engineering</td>
                                                            <td>30</td>
                                                        </tr>
                                                        <tr>
                                                            <td>6</td>
                                                            <td>Department of Chemical Engineering</td>
                                                            <td>30</td>
                                                        </tr>
                                                        <tr>
                                                            <td>7</td>
                                                            <td>Department of Mechatronics Engineering</td>
                                                            <td>60</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </section>
                                        </main>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="facilities" id="facility">
            <h1>Our Facilities</h1>
            <div class="facility-row">

                <div class="facilities-col">
                    <a href="#popup-auditorium">
                        <img src="CSS/Resources/Facilities/auditorium.jpg">
                        <h3>Auditorium</h3>
                    </a>
                    <div id="popup-auditorium" class="overlay">
                        <div class="popup">
                            <h2 style="margin-bottom: 8px;">Auditorium</h2>
                            <a class="close" href="#">&times;</a>
                            <div class="content">
                                <div class="slider">
                                    <div class="images">
                                        <input type="radio" name="slide"
                                            id="a-image1" checked>
                                        <input type="radio" name="slide"
                                            id="a-image2">
                                        <input type="radio" name="slide"
                                            id="a-image3">
                                        <input type="radio" name="slide"
                                            id="a-image4">

                                        <img src="CSS/Resources/Facilities/auditorium.jpg"
                                            class="a-i1" alt="image1">
                                        <img src="CSS/Resources/Facilities/auditorium (1).jpg"
                                            class="a-i2" alt="image2">
                                        <img src="CSS/Resources/Facilities/auditorium (2).jpeg"
                                            class="a-i3" alt="image3">
                                        <img src="CSS/Resources/Facilities/auditorium (3).jpg"
                                            class="a-i4" alt="image4">
                                    </div>
                                    <div class="dots">
                                        <label for="a-image1"></label>
                                        <label for="a-image2"></label>
                                        <label for="a-image3"></label>
                                        <label for="a-image4"></label>
                                    </div>
                                    <div class="info">
                                        <p>Hermann Hall, designed in 1962 by Walter Netsch for Skidmore, Owings & Merrill, echoes Galvin Library with its glass curtain wall and internally supported huge plate girders spanning the roof. The heavy pebble aggregate reinforced concrete support columns inside suggest something of the scale of the clear spans. McCormick Auditorium, which seats 836 people and is HMIT's largest auditorium, is cradled between these columns.<br>
                                            Hermann Hall has meeting, multipurpose and classroom spaces that fit a variety of event types and sizes. For reservation information contact the Office of Event Services.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="facilities-col">
                    <a href="#popup-library">
                        <img src="CSS/Resources/Facilities/library.jpg">
                        <h3>Library</h3>
                    </a>
                    <div id="popup-library" class="overlay">
                        <div class="popup">
                            <h2 style="margin-bottom: 8px;">Central Library</h2>
                            <a class="close" href="#">&times;</a>
                            <div class="content">
                                <div class="slider">
                                    <div class="images">
                                        <input type="radio" name="slide"
                                            id="l-image1" checked>
                                        <input type="radio" name="slide"
                                            id="l-image2">
                                        <input type="radio" name="slide"
                                            id="l-image3">
                                        <input type="radio" name="slide"
                                            id="l-image4">

                                        <img src="CSS/Resources/Facilities/library.jpg"
                                            class="l-i1" alt="image1">
                                        <img src="CSS/Resources/Facilities/library (1).jpg"
                                            class="l-i2" alt="image2">
                                        <img src="CSS/Resources/Facilities/library (2).jpg"
                                            class="l-i3" alt="image3">
                                        <img src="CSS/Resources/Facilities/library (3).jpg"
                                            class="l-i4" alt="image4">
                                    </div>
                                    <div class="dots">
                                        <label for="l-image1"></label>
                                        <label for="l-image2"></label>
                                        <label for="l-image3"></label>
                                        <label for="l-image4"></label>
                                    </div>
                                    <div class="info">
                                        <p>Welcome to the Central Library which is one of the central support services of HMIT. The mission of the Central Library is to provide information services and access to bibliographic and full text digital and printed resources to support the scholarly and informational needs of the Institute Community.<br>
                                            The Central Library is well equipped with modern facilities and resources in the form of CD-ROMs, On-line databases, audio video cassettes, books, e-journals, patents, e-standards, theses, reports, monographs etc. The library homepage will provide electronic access to various full text & bibliographical databases & e-journals.<br>
                                            The Central Library has 9001:2015 certification by TUV NORD of Germany along with other units of the Institute for the establishment and maintenance of quality library system, services & procedures. Links from the home page will direct you to information on library policies, hours, collections, services, sections and the location of materials.<br>
                                            We invite you to visit the library in order to enjoy the wealth of printed resources available on our shelves.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="facilities-col">
                    <a href="#popup-playground">
                        <img src="CSS/Resources/Facilities/playground.jpeg">
                        <h3>Play Ground</h3>
                    </a>
                    <div id="popup-playground" class="overlay">
                        <div class="popup">
                            <h2 style="margin-bottom: 8px;">Central Field</h2>
                            <a class="close" href="#">&times;</a>
                            <div class="content">
                                <div class="slider">
                                    <div class="images">
                                        <input type="radio" name="slide"
                                            id="p-image1" checked>
                                        <input type="radio" name="slide"
                                            id="p-image2">
                                        <input type="radio" name="slide"
                                            id="p-image3">
                                        <input type="radio" name="slide"
                                            id="p-image4">

                                        <img src="CSS/Resources/Facilities/playground.jpeg"
                                            class="p-i1" alt="image1">
                                        <img src="CSS/Resources/Facilities/playground (1).jpg"
                                            class="p-i2" alt="image2">
                                        <img src="CSS/Resources/Facilities/playground (2).jpg"
                                            class="p-i3" alt="image3">
                                        <img src="CSS/Resources/Facilities/playground (3).jpg"
                                            class="p-i4" alt="image4">
                                    </div>
                                    <div class="dots">
                                        <label for="p-image1"></label>
                                        <label for="p-image2"></label>
                                        <label for="p-image3"></label>
                                        <label for="p-image4"></label>
                                    </div>
                                    <div class="info">
                                        <p>During childhood and adolescence, regular physical activity is associated with improvements in both physiological and psychological health. Therefore, the promotion of regular physical activity in youth has become a public health priority. Metropolitan University is not only concerned about making competent graduates but also concerned about making healthy (both psychologically and physically) future citizens.<br>
                                            The permanent campus of HMIT has a wide and spacious playground. Students often arrange various inter-department tournaments of Cricket, Football, Badminton etc. games that generally take place at the university playground. HMIT students often take part in various national and international tournaments and prove their sportsman spirit which also helps them to be open-minded & improved human beings.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="facilities-col">
                    <a href="#popup-cafeteria">
                        <img src="CSS/Resources/Facilities/cafeteria.jpg">
                        <h3>Cafeteria</h3>
                    </a>
                    <div id="popup-cafeteria" class="overlay">
                        <div class="popup">
                            <h2 style="margin-bottom: 8px;">Cafeteria</h2>
                            <a class="close" href="#">&times;</a>
                            <div class="content">
                                <div class="slider">
                                    <div class="images">
                                        <input type="radio" name="slide"
                                            id="c-image1" checked>
                                        <input type="radio" name="slide"
                                            id="c-image2">
                                        <input type="radio" name="slide"
                                            id="c-image3">
                                        <input type="radio" name="slide"
                                            id="c-image4">

                                        <img src="CSS/Resources/Facilities/cafeteria.jpg"
                                            class="c-i1" alt="image1">
                                        <img src="CSS/Resources/Facilities/cafeteria (1).jpg"
                                            class="c-i2" alt="image2">
                                        <img src="CSS/Resources/Facilities/cafeteria (2).jpg"
                                            class="c-i3" alt="image3">
                                        <img src="CSS/Resources/Facilities/cafeteria (3).jpg"
                                            class="c-i4" alt="image4">
                                    </div>
                                    <div class="dots">
                                        <label for="c-image1"></label>
                                        <label for="c-image2"></label>
                                        <label for="c-image3"></label>
                                        <label for="c-image4"></label>
                                    </div>
                                    <div class="info">
                                        <p>Are you vegan? Gluten-free? On the "see-food diet" (you see food, you eat it)? Illinois Tech’s dining locations offer it all, and you know you're in good hands because our students help to select the menus each semester. Our fresh, healthy options are open to both on-campus residents and commuter students, in addition to faculty and guests.
                                            <br>
                                            In addition to traditional cafeteria service be sure to check out on-campus locations for Saffron Indian and Middle Eastern and Halal foods, Asiana Cuisine and Tea House, and Do-Rite Donuts. Just want a quick pick-me-up? Grab a smoothie or Metropolis or Starbuck's coffee at one of our on-campus cafes.<br>
                                            When you live on campus you can choose from a number of meal plan options, many of which come with an allotment of bonus points each semester.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="facilities-col">
                    <a href="#popup-science">
                        <img src="CSS/Resources/Facilities/science_lab.jpg">
                        <h3>Science Lab</h3>
                    </a>
                    <div id="popup-science" class="overlay">
                        <div class="popup">
                            <h2 style="margin-bottom: 8px;">Science Lab</h2>
                            <a class="close" href="#">&times;</a>
                            <div class="content">
                                <div class="slider">
                                    <div class="images">
                                        <input type="radio" name="slide"
                                            id="s-image1" checked>
                                        <input type="radio" name="slide"
                                            id="s-image2">
                                        <input type="radio" name="slide"
                                            id="s-image3">
                                        <input type="radio" name="slide"
                                            id="s-image4">

                                        <img src="CSS/Resources/Facilities/science_lab.jpg"
                                            class="s-i1" alt="image1">
                                        <img src="CSS/Resources/Facilities/science_lab (1).jpg"
                                            class="s-i2" alt="image2">
                                        <img src="CSS/Resources/Facilities/science_lab (2).jpg"
                                            class="s-i3" alt="image3">
                                        <img src="CSS/Resources/Facilities/science_lab (3).jpg"
                                            class="s-i4" alt="image4">
                                    </div>
                                    <div class="dots">
                                        <label for="s-image1"></label>
                                        <label for="s-image2"></label>
                                        <label for="s-image3"></label>
                                        <label for="s-image4"></label>
                                    </div>
                                    <div class="info">
                                        <p>Science Laboratory uses the tools of engineering, biology, and chemistry to determine solutions to the intractable challenges posed by chronic wounds. One fundamental challenge of chronic wounds is the excessive degradation of fibronectin, an important scaffolding protein. We are engineering strategies to stabilize fibronectin against degradation. We are also developing biological mimics of natural scaffolds based on functional units in fibronectin. In addition to formulating these biomimics, we create strategies to optimize function and activity of these biological substitutes.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="facilities-col">
                    <a href="#popup-computer">
                        <img src="CSS/Resources/Facilities/computer_lab.jpg">
                        <h3>Computer Lab</h3>
                    </a>
                    <div id="popup-computer" class="overlay">
                        <div class="popup">
                            <h2 style="margin-bottom: 8px;">Computer Lab</h2>
                            <a class="close" href="#">&times;</a>
                            <div class="content">
                                <div class="slider">
                                    <div class="images">
                                        <input type="radio" name="slide"
                                            id="cp-image1" checked>
                                        <input type="radio" name="slide"
                                            id="cp-image2">
                                        <input type="radio" name="slide"
                                            id="cp-image3">
                                        <input type="radio" name="slide"
                                            id="cp-image4">

                                        <img src="CSS/Resources/Facilities/computer_lab.jpg"
                                            class="cp-i1" alt="image1">
                                        <img src="CSS/Resources/Facilities/computer_lab (1).jpg"
                                            class="cp-i2" alt="image2">
                                        <img src="CSS/Resources/Facilities/computer_lab (2).jpeg"
                                            class="cp-i3" alt="image3">
                                        <img src="CSS/Resources/Facilities/computer_lab (3).jpeg"
                                            class="cp-i4" alt="image4">
                                    </div>
                                    <div class="dots">
                                        <label for="cp-image1"></label>
                                        <label for="cp-image2"></label>
                                        <label for="cp-image3"></label>
                                        <label for="cp-image4"></label>
                                    </div>
                                    <div class="info">
                                        <p>PC Lab provides general computing facilities to students of Electrical Engineering and Reliability Engineering. Both Windows and Linux machines are present in the lab. In addition, a load-balanced server is available for heavier computational use. Software packages like MATLAB, Lyx, Scilab, Spice, Ansys, Sequel, Grace, etc. are installed on Rudra. You can use them for your (academic) work. Standard Linux/unix packages, such as LaTeX, mysql, etc are also available. In addition to Rudra Pclab also provides mail service with a central storage of 500MB to all students and faculty of the department. Team of System Adminstrators provide the tech-end support to the department. All the network infrastructure in the department is maintained the team.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="facilities-col">
                    <a href="#popup-pool">
                        <img src="CSS/Resources/Facilities/swimming_pool.jpg">
                        <h3>Swimming Pool</h3>
                    </a>
                    <div id="popup-pool" class="overlay">
                        <div class="popup">
                            <h2 style="margin-bottom: 8px;">Swimming Pool</h2>
                            <a class="close" href="#">&times;</a>
                            <div class="content">
                                <div class="slider">
                                    <div class="images">
                                        <input type="radio" name="slide"
                                            id="sp-image1" checked>
                                        <input type="radio" name="slide"
                                            id="sp-image2">
                                        <input type="radio" name="slide"
                                            id="sp-image3">
                                        <input type="radio" name="slide"
                                            id="sp-image4">

                                        <img src="CSS/Resources/Facilities/swimming_pool.jpg"
                                            class="sp-i1" alt="image1">
                                        <img src="CSS/Resources/Facilities/swimming_pool (1).jpg"
                                            class="sp-i2" alt="image2">
                                        <img src="CSS/Resources/Facilities/swimming_pool (2).jpg"
                                            class="sp-i3" alt="image3">
                                        <img src="CSS/Resources/Facilities/swimming_pool (3).jpg"
                                            class="sp-i4" alt="image4">
                                    </div>
                                    <div class="dots">
                                        <label for="sp-image1"></label>
                                        <label for="sp-image2"></label>
                                        <label for="sp-image3"></label>
                                        <label for="sp-image4"></label>
                                    </div>
                                    <div class="info">
                                        <p>Comprising of Swimming and Water Polo, Aquatics is one of the most widely practiced sports at IIT Bombay. Owing to the remarkable infrastructure facilities consisting of an Olympic-sized Swimming Pool, accompanied by a Beginners Baby Pool, IIT Bombay Aquatics has witnessed a tremendous growth over the years. IITB Swimming Pool is also affiliated to the Greater Mumbai Amateur Aquatic Association(GMAAA). With several exciting events spread throughout the year to cater to all levels of players, IITB Aquatics functions with the sole aim of promoting Swimming and Water Polo. Coached by Ritesh Guchhait, the Swimming and Water Polo teams of IIT Bombay have the most successful history and a reputable name at the Inter-IIT Aquatics Meet.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="facilities-col">
                    <a href="#popup-common">
                        <img src="CSS/Resources/Facilities/common_room.jpg">
                        <h3>Common Room</h3>
                    </a>
                    <div id="popup-common" class="overlay">
                        <div class="popup">
                            <h2 style="margin-bottom: 8px;">Common Room</h2>
                            <a class="close" href="#">&times;</a>
                            <div class="content">
                                <div class="slider">
                                    <div class="images">
                                        <input type="radio" name="slide"
                                            id="cm-image1" checked>
                                        <input type="radio" name="slide"
                                            id="cm-image2">
                                        <input type="radio" name="slide"
                                            id="cm-image3">
                                        <input type="radio" name="slide"
                                            id="cm-image4">

                                        <img src="CSS/Resources/Facilities/common_room.jpg"
                                            class="cm-i1" alt="image1">
                                        <img src="CSS/Resources/Facilities/common_room (1).jpg"
                                            class="cm-i2" alt="image2">
                                        <img src="CSS/Resources/Facilities/common_room (2).jpg"
                                            class="cm-i3" alt="image3">
                                        <img src="CSS/Resources/Facilities/common_room (3).jpeg"
                                            class="cm-i4" alt="image4">
                                    </div>
                                    <div class="dots">
                                        <label for="cm-image1"></label>
                                        <label for="cm-image2"></label>
                                        <label for="cm-image3"></label>
                                        <label for="cm-image4"></label>
                                    </div>
                                    <div class="info">
                                        <p>Advice and lectures on keeping your grades intact, studying well and getting good placements will never die down, even after getting accepted into an institute like IIT. College has been said to be the place where we can experiment and experience everything in life and the constant reminder that we are here to study often creates a lot of external pressure. Victory is when you learn to balance your academic life and your social life. Sustained efforts are required to maintain your academic performance, and the availability of a study space satisfying all your study needs is a prerequisite.<br>
                                            A study space is not just somewhere you sit to meet your credit requirements, but a potpourri of elements  delicately balanced to serve your slim attention span. It includes a place, often matching your taste and preference, furniture, study materials, electronic devices, easy availability of  snacks, water coolers, restrooms, good lighting, air conditioning and so on. The perfect study space does not exist. Besides being very subjective, between the unforgiving Chennai heat and the requirements of WiFi and charging ports, students have slim pickings.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="facilities-col">
                    <a href="#popup-indoor">
                        <img src="CSS/Resources/Facilities/indoor_games.jpg">
                        <h3>Indoor Games</h3>
                    </a>
                    <div id="popup-indoor" class="overlay">
                        <div class="popup">
                            <h2 style="margin-bottom: 8px;">Indoor Games</h2>
                            <a class="close" href="#">&times;</a>
                            <div class="content">
                                <div class="slider">
                                    <div class="images">
                                        <input type="radio" name="slide"
                                            id="i-image1" checked>
                                        <input type="radio" name="slide"
                                            id="i-image2">
                                        <input type="radio" name="slide"
                                            id="i-image3">
                                        <input type="radio" name="slide"
                                            id="i-image4">

                                        <img src="CSS/Resources/Facilities/indoor_games.jpg"
                                            class="i-i1" alt="image1">
                                        <img src="CSS/Resources/Facilities/indoor_games (1).png"
                                            class="i-i2" alt="image2">
                                        <img src="CSS/Resources/Facilities/indoor_games (2).jpg"
                                            class="i-i3" alt="image3">
                                        <img src="CSS/Resources/Facilities/indoor_games (3).jpeg"
                                            class="i-i4" alt="image4">
                                    </div>
                                    <div class="dots">
                                        <label for="i-image1"></label>
                                        <label for="i-image2"></label>
                                        <label for="i-image3"></label>
                                        <label for="i-image4"></label>
                                    </div>
                                    <div class="info">
                                        <p>The Students’ Activity Centre is the nerve centre of all student activities on the campus. With a moat on one side and a high stone-wall on the other, the Students’ Activity Centre recalls to the visitors memories of an ancient fort. The Centre comprising a Club Building, Gymnasium Hall, Swimming Pool, Amphitheatre, Music Rooms, Hobbies Workshop and a large Dark Room, caters to various hobbies of the students. They have a place to paint, to sculpt or to tinker with the radio. There are committee rooms where they can hold formal or informal meetings and a large marble-floored hall for exhibitions. On the first floor of the Centre, students have facility to play billiards.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="facilities-col">
                    <a href="#popup-gym">
                        <img src="CSS/Resources/Facilities/gymnasium.jpg">
                        <h3>Gymnasium</h3>
                    </a>
                    <div id="popup-gym" class="overlay">
                        <div class="popup">
                            <h2 style="margin-bottom: 8px;">Gymnasium</h2>
                            <a class="close" href="#">&times;</a>
                            <div class="content">
                                <div class="slider">
                                    <div class="images">
                                        <input type="radio" name="slide"
                                            id="g-image1" checked>
                                        <input type="radio" name="slide"
                                            id="g-image2">
                                        <input type="radio" name="slide"
                                            id="g-image3">
                                        <input type="radio" name="slide"
                                            id="g-image4">

                                        <img src="CSS/Resources/Facilities/gymnasium.jpg"
                                            class="g-i1" alt="image1">
                                        <img src="CSS/Resources/Facilities/gymnasium (1).jpeg"
                                            class="g-i2" alt="image2">
                                        <img src="CSS/Resources/Facilities/gymnasium (2).jpeg"
                                            class="g-i3" alt="image3">
                                        <img src="CSS/Resources/Facilities/gymnasium (3).jpeg"
                                            class="g-i4" alt="image4">
                                    </div>
                                    <div class="dots">
                                        <label for="g-image1"></label>
                                        <label for="g-image2"></label>
                                        <label for="g-image3"></label>
                                        <label for="g-image4"></label>
                                    </div>
                                    <div class="info">
                                        <p>The large gymnasium hall is over 10 m. high where the students have a place for badminton in inclement weather or to engage themselves in gymnastics. The Institute has a 16-exercise multigym. A large swimming pool with clean blue water makes their campus life cool in summer. The swimming pool is indeed the most popular sport for students during the hot summer. The pride of the Centre is its huge Amphitheatre which can accommodate 2,000 persons. With a magnificent stage and attached green rooms it is perhaps one of the finest of its kind in the country.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </section>

        <section class="cta">
            <h1>HM INSTITUTE OF TECHNOLOGY</h1>
            <asp:Button ID="Button1" class="hero-btn" runat="server" Text="CONTACT US" OnClick="contact_Click" />
        </section>

        <section class="footer" id="contact">
            <h4>Contact</h4>
            <p>HM Institute of Technology <b>(HMIT)</b>, Khulna-9203, Bangladesh</p>
            <p>
                <b>Phone: </b>
                <p>+88024777 32971</p>
                <p>+88024777 33303</p>
            </p>
            <p>
                <b>Email: </b>
                admin@hmit.ac.bd
            </p>
        </section>
    </form>

    <script src="JavaScript/navigation.js"></script>
</body>
</html>
