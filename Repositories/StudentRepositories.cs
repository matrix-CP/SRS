using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SRS.Models;
using Npgsql;
using WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SRS.Repositories
{
    public class StudentRepositories : CommanRepositories,IStudentRepositories
    {
        public bool InsertStudent(tblStudent student)
        {

            conn.Open();

            using (var command = new NpgsqlCommand("INSERT INTO t_student_registration (c_name, c_birthdate, c_gender, c_address, c_language, c_course, c_profile, c_document, c_mobile) VALUES (@name, @birthdate, @gender, @address, @language, @course, @profile, @document, @mobile);", conn))
            {
                command.Parameters.AddWithValue("@name", student.c_studentid);
                command.Parameters.AddWithValue("@birthdate", student.c_birthdate);
                command.Parameters.AddWithValue("@gender", student.c_gender);
                command.Parameters.AddWithValue("@address", student.c_address);

                string selectedLanguages = string.Join(",", student.c_language);
                command.Parameters.AddWithValue("@language", selectedLanguages);

                command.Parameters.AddWithValue("@course", student.c_course);
                command.Parameters.AddWithValue("@profile", student.c_profile);
                command.Parameters.AddWithValue("@document", student.c_document);
                command.Parameters.AddWithValue("@mobile", student.c_mobile);

                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        public List<tblStudent> FetchAllStudents()
        {
            var students = new List<tblStudent>();

            conn.Open();
            using (var command = new NpgsqlCommand("SELECT s.c_studentid, s.c_name, s.c_birthdate, s.c_gender, s.c_address, s.c_language, s.c_course, s.c_profile, s.c_document, s.c_mobile, c.c_coursename FROM t_student_registration s INNER JOIN t_course c ON s.c_course = c.c_courseid;", conn))
            {
                // command.CommandType = CommandType.Text;
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = new tblStudent
                            {
                                c_studentid = Convert.ToInt32(reader["c_studentid"]),
                                c_name = reader["c_name"].ToString(),
                                c_birthdate = DateTime.Parse(reader["c_birthdate"].ToString()).Date,
                                c_address = reader["c_address"].ToString(),
                                c_gender = reader["c_gender"].ToString(),
                                c_language = reader["c_language"].ToString().Split(',').ToList(),
                                c_course = Convert.ToInt32(reader["c_course"]),
                                c_coursename = reader["c_coursename"].ToString(),
                                c_profile = reader["c_profile"].ToString(),
                                c_document = reader["c_document"].ToString(),
                                c_mobile = Convert.ToInt64(reader["c_mobile"].ToString())
                            };
                            students.Add(student);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
            return students;
        }

        public tblStudent FetchStudentDetails(int c_studentid)
        {
            var student = new tblStudent();
            try
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT s.c_studentid, s.c_name, s.c_birthdate, s.c_gender, s.c_address, s.c_language, s.c_course, s.c_profile, s.c_document, s.c_mobile, c.c_coursename FROM t_student_registration s INNER JOIN t_course c ON s.c_course = c.c_courseid WHERE s.c_studentid = @c_studentid;", conn))
                {
                    // command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@c_studentid", c_studentid);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            student.c_studentid = Convert.ToInt32(reader["c_studentid"]);
                            student.c_name = reader["c_name"].ToString();
                            student.c_birthdate = DateTime.Parse(reader["c_birthdate"].ToString()).Date;
                            student.c_address = reader["c_address"].ToString();
                            student.c_gender = reader["c_gender"].ToString();
                            student.c_language = reader["c_language"].ToString().Split(',').ToList();
                            // student.Course = Convert.ToInt32(reader["c_course"]);
                            student.c_coursename = reader["c_coursename"].ToString();
                            student.c_profile = reader["c_profile"].ToString();
                            student.c_document = reader["c_document"].ToString();
                            student.c_mobile = Convert.ToInt64(reader["c_mobile"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return student;
        }


        public bool UpdateExistingStudent(tblStudent student)
        {
            // NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            using var command = new NpgsqlCommand("UPDATE t_student_registration SET c_name = @name, c_birthdate = @dob, c_address = @address, c_gender = @gender, c_language = @language, c_profile = @profile, c_document = @document, c_mobile = @mobile, c_course = @course WHERE c_studentid = @id;", conn);
            command.Parameters.AddWithValue("@id", student.c_studentid);
            command.Parameters.AddWithValue("@name", student.c_name);
            command.Parameters.AddWithValue("@dob", student.c_birthdate);
            command.Parameters.AddWithValue("@address", student.c_address);
            command.Parameters.AddWithValue("@gender", student.c_gender);
            string selectedLanguages = string.Join(",", student.c_language);
            command.Parameters.AddWithValue("@language", selectedLanguages);

            command.Parameters.AddWithValue("@profile", student.c_profile);
            command.Parameters.AddWithValue("@document", student.c_document);
            command.Parameters.AddWithValue("@mobile", student.c_mobile);
            command.Parameters.AddWithValue("@course", student.c_course);

            conn.Open();
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool DeleteStudentDetails(int c_studentid)
        {
            conn.Open();
            using (var command = new NpgsqlCommand("DELETE FROM t_student_registration WHERE c_studentid = @c_studentid;", conn))
            {
                // command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@c_studentid", c_studentid);
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<SelectListItem> GetAllCourse()
        {
            List<SelectListItem> courseList = new List<SelectListItem>();
            try
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT c_courseid, c_coursename FROM t_course", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var course = new SelectListItem
                            {
                                Value = reader["c_courseid"].ToString(),
                                Text = reader["c_coursename"].ToString()
                            };
                            courseList.Add(course);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally{
                conn.Close();
            }
            return courseList;
        }
    }
}