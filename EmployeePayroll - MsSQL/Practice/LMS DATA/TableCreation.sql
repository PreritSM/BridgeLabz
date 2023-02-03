--CREATE DATABASE LmsData;
--use LmsData;

CREATE TABLE hired_candidates (
  id int NOT NULL Primary Key,
  first_name varchar(100) NOT NULL,
  middle_name varchar(100) DEFAULT NULL,
  last_name varchar(100) NOT NULL,
  email varchar(50) NOT NULL,
  mobile_num bigint NOT NULL,
  hired_city varchar(50) NOT NULL,
  hired_date datetime NOT NULL,
  degree varchar(100) NOT NULL,
  aggr_per float DEFAULT NULL,
  current_pincode int DEFAULT NULL,
  permanent_pincode int DEFAULT NULL,
  hired_lab varchar(20) DEFAULT NULL,
  attitude_remark varchar(15) DEFAULT NULL,
  communication_remark varchar(15) DEFAULT NULL,
  knowledge_remark varchar(15) DEFAULT NULL,
  status varchar(20) NOT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
)

CREATE TABLE fellowship_candidates (
  id int NOT NULL Primary Key,
  first_name varchar(100) NOT NULL,
  middle_name varchar(100) DEFAULT NULL,
  last_name varchar(100) NOT NULL,
  email varchar(50) NOT NULL,
  mobile_num bigint NOT NULL,
  hired_city varchar(50) NOT NULL,
  hired_date datetime NOT NULL,
  degree varchar(50) NOT NULL,
  aggr_per float DEFAULT NULL,
  current_pincode int DEFAULT NULL,
  permanent_pincode int DEFAULT NULL,
  hired_lab varchar(20) DEFAULT NULL,
  attitude_remark varchar(15) DEFAULT NULL,
  communication_remark varchar(15) DEFAULT NULL,
  knowledge_remark varchar(15) DEFAULT NULL,
  birth_date date NOT NULL,
  is_birth_date_verified int DEFAULT 0,
  parent_name varchar(50) DEFAULT NULL,
  parent_occupation varchar(100) NOT NULL,
  parent_mobile_num bigint NOT NULL,
  parent_annual_sal float DEFAULT NULL,
  local_addr varchar(255) NOT NULL,
  permanent_addr varchar(150) DEFAULT NULL,
  photo_path varchar(500) DEFAULT NULL,
  joining_date date DEFAULT NULL,
  candidate_status varchar(20) NOT NULL,
  personal_info_filled int DEFAULT 0,
  bank_info_filled int DEFAULT 0,
  educational_info_filled int DEFAULT 0,
  doc_status varchar(20) DEFAULT NULL,
  remark varchar(150) DEFAULT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL
)

insert into fellowship_candidates values(1, 'deepak', 'Kiran', 'Patil', 'deepak.63584@gmail.com ', 8956748596, 'Pune','2019-12-13','B.E'     , 75.25,5245,5478,'Mumbai', 'Good', 'Good'     , 'Good', '1999-12-13', 1, 'Kiran', 'Farmer'     , 7584962547, 300000, 'Pune', 'Pune'     , 'photo_path', '2019-12-13', 'Good', 1, 1, 1, 'Correct', 'Good', null, 1);

CREATE TABLE candidates_personal_det_check (
  id int NOT NULL,
  candidate_id  int NOT NULL,
  field_name int NOT NULL,
  is_verified int DEFAULT NULL,
  lastupd_stamp datetime DEFAULT NULL,
  lastupd_user int DEFAULT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL
);

	CREATE TABLE candidate_bank_det(
	  id int NOT NULL Primary Key,
	  candidate_id int NOT NULL,
	  name varchar(100) NOT NULL,
	  account_num int NOT NULL,
	  is_account_num_verified int DEFAULT 0,
	  ifsc_code varchar(20) NOT NULL,
	  is_ifsc_code_verified int DEFAULT 0,
	  pan_number varchar(10) DEFAULT NULL,
	  is_pan_number_verified int DEFAULT 0,
	  addhaar_num int NOT NULL,
	  is_addhaar_num_verified int DEFAULT 0,
	  FOREIGN KEY (candidate_id) REFERENCES fellowship_candidates(id),
	  creator_stamp datetime DEFAULT NULL,
	  creator_user int DEFAULT NULL,
	) 

CREATE TABLE candidates_bank_det_check (
  id int NOT NULL,
  candidate_id  int NOT NULL,
  field_name int NOT NULL,
  is_verified int DEFAULT NULL,
  lastupd_stamp datetime DEFAULT NULL,
  lastupd_user int DEFAULT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL
);

CREATE TABLE candidate_qualification(
  id int NOT NULL Primary Key,
  candidate_id int NOT NULL,
  diploma int DEFAULT 0,
  degree_name varchar(10) NOT NULL,
  is_degree_name_verified int DEFAULT 0,
  employee_decipline varchar(100) NOT NULL,
  is_employee_decipline_verified int DEFAULT 0,
  passing_year int NOT NULL,
  is_passing_year_verified int DEFAULT 0,
  aggr_per float DEFAULT NULL,
  final_year_per float DEFAULT NULL,
  is_final_year_per_verified int DEFAULT 0,
  training_institute varchar(20) NOT NULL,
  is_training_institute_verified int DEFAULT 0,
  training_duration_month int DEFAULT NULL,
  is_training_duration_month_verified int DEFAULT 0,
  other_training varchar(255) DEFAULT NULL,
  is_other_training_verified int DEFAULT 0,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,

 FOREIGN KEY (candidate_id) REFERENCES fellowship_candidates (id),
) ;

CREATE TABLE candidates_education_det_check (
  id int NOT NULL,
  candidate_id  int NOT NULL,
  field_name int NOT NULL,
  is_verified int DEFAULT NULL,
  lastupd_stamp datetime DEFAULT NULL,
  lastupd_user int DEFAULT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL
);

CREATE TABLE candidate_docs(
  id int NOT NULL Primary Key,
  candidate_id int NOT NULL,
  doc_type varchar(20) DEFAULT NULL,
  doc_path varchar(500) DEFAULT NULL,
  status int DEFAULT 1,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
   
  FOREIGN KEY (candidate_id) REFERENCES fellowship_candidates(id),
 
) 

CREATE TABLE user_details (
  id int NOT NULL Primary Key,
  email varchar(50) NOT NULL Unique,
  first_name varchar(100) NOT NULL,
  last_name varchar(100) NOT NULL,
  password varchar(15) NOT NULL,
  contact_number bigint NOT NULL,
  verified bit DEFAULT NULL, 
) 

CREATE TABLE user_roles (
  user_id int NOT NULL ,
  role_name varchar(100)
) 

CREATE TABLE company(
  id int NOT NULL,
  name int NOT NULL,
  address varchar(150) DEFAULT NULL,
  location varchar(50) DEFAULT NULL,
  status int DEFAULT 1,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  PRIMARY KEY (id)
) 

CREATE TABLE tech_type (
  id int NOT NULL,
  type_name varchar(50) NOT NULL,
  cur_status char(1) DEFAULT NULL,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL
) 

CREATE TABLE maker_program(
  id int NOT NULL,
  program_name int NOT NULL,
  program_type varchar(10) DEFAULT NULL,
  program_link text DEFAULT NULL,
  tech_stack_id int DEFAULT NULL,
  tech_type_id int NOT NULL,
  is_program_approved int,
  description varchar(500) DEFAULT NULL,
  status int DEFAULT 1,
  creator_stamp datetime DEFAULT NULL,
  creator_user int DEFAULT NULL,
  FOREIGN KEY (tech_stack_id) REFERENCES tech_stack(id),
  FOREIGN KEY (tech_type_id) REFERENCES tech_type(id),
  PRIMARY KEY (id)
) 






