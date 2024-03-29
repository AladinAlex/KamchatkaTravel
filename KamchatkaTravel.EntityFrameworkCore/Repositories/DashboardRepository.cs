﻿using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Domain.Tours;
using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.EntityFrameworkCore.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        readonly KamchatkaTravelDbContext _context;
        public DashboardRepository(KamchatkaTravelDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ClientRequest>> SelectClientRequestAllAsync()
        {
            var result = await _context.ClientRequests.AsNoTracking().Where(x => x.Visible).Include(x => x.tour).ToListAsync();
            return result;
        }

        public async Task UpdateProcessClientRequestAsync(Guid Id)
        {
            var cl = await _context.ClientRequests.FirstAsync(x => x.Id == Id);
            cl.isProcessed = !cl.isProcessed;
            await _context.SaveChangesAsync();
        }

        public async Task<ClientRequest> SelectClientRequestByIdAsync(Guid Id)
        {
            var cl = await _context.ClientRequests.FirstAsync(x => x.Id == Id && x.Visible);
            return cl;
        }

        public async Task UpdateClientRequestByIdAsync(Guid Id, string comment)
        {
            var cl = await _context.ClientRequests.FirstAsync(x => x.Id == Id);

            if (cl.comment != comment)
            {
                cl.comment = comment;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteClientRequestByIdAsync(Guid Id)
        {
            var cl = await _context.ClientRequests.FirstAsync(x => x.Id == Id);
            cl.Visible = false;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Tour>> SelectTourAllAsync(bool? isVisible = null)
        {
            var result = _context.Tours.AsNoTracking();
            if (isVisible != null)
                result = result.Where(x => x.Visible == isVisible);
            return await result.ToListAsync();
        }
        public async Task<IEnumerable<Review>> SelectReviewAllAsync(bool? isVisible = null)
        {
            var result = _context.Reviews.AsNoTracking();
            if (isVisible != null)
                result = result.Where(x => x.Visible == isVisible);
            return await result.ToListAsync();
        }
        public async Task<Tour> GetTourByIdAsync(Guid Id)
        {
            var t = await _context.Tours.AsNoTracking()
                .Include(x => x.Views)
                .Include(x => x.Images)
                .Include(x => x.Days)
                .Include(x => x.Questions)
                .Include(x => x.Includes)
                .FirstAsync(x => x.Id == Id);
            return t;
        }
        public async Task UpdateTourAsync(Tour newTour)
        {
            var t = await _context.Tours.FirstAsync(x => x.Id == newTour.Id);

            if(t.Name != newTour.Name)
            {
                t.RouteName = KamchatkaTravel.Domain.Shared.Utils.Tools.GetRouteByName(newTour.Name);
                t.Name = newTour.Name;
            }

            t.Tagline = newTour.Tagline;
            
            if (!string.IsNullOrWhiteSpace(newTour.LogoImageUrl))
                t.LogoImageUrl = newTour.LogoImageUrl;

            t.SeasonType = newTour.SeasonType;
            t.NightType = newTour.NightType;
            t.Price = newTour.Price;
            t.Description = newTour.Description;

            if (!string.IsNullOrWhiteSpace(newTour.DescriptionImageUrl))
                t.DescriptionImageUrl = newTour.DescriptionImageUrl;

            t.LinkEquipment = newTour.LinkEquipment;
            t.Visible = newTour.Visible;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateViewAsync(View newView)
        {
            var v = await _context.Views.FirstAsync(x => x.Id == newView.Id);
            v.Visible = newView.Visible;

            if (!string.IsNullOrWhiteSpace(newView.ImageUrl))
                v.ImageUrl = newView.ImageUrl;

            v.Description = newView.Description;
            v.Name = newView.Name;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateImageAsync(Image newImage)
        {
            var v = await _context.Images.FirstAsync(x => x.Id == newImage.Id);
            v.Visible = newImage.Visible;
            v.Ord = newImage.Ord;

            if (!string.IsNullOrWhiteSpace(newImage.ImageUrl))
                v.ImageUrl = newImage.ImageUrl;

            await _context.SaveChangesAsync();
        }
        public async Task UpdateDayAsync(Day newDay)
        {
            var d = await _context.Days.FirstAsync(x => x.Id == newDay.Id);
            d.Visible = newDay.Visible;
            d.Name = newDay.Name;
            d.Description = newDay.Description;
            d.Number = newDay.Number;

            if (!string.IsNullOrWhiteSpace(newDay.ImageUrl))
                d.ImageUrl = newDay.ImageUrl;

            await _context.SaveChangesAsync();
        }
        public async Task UpdateReviewAsync(Review newReview)
        {
            var d = await _context.Reviews.FirstAsync(x => x.Id == newReview.Id);
            d.Visible = newReview.Visible;
            d.FirstName = newReview.FirstName;
            d.LastName = newReview.LastName;
            d.Text = newReview.Text;
            d.Date = newReview.Date;
            if(!string.IsNullOrWhiteSpace(newReview.LogoImageUrl))
                d.LogoImageUrl = newReview.LogoImageUrl;

            //if (newReview.LogoImage != null && newReview.LogoImage.Any())
            //    d.LogoImage = newReview.LogoImage;

            await _context.SaveChangesAsync();
        }
        public async Task UpdateQuestionAsync(Question newQuestion)
        {
            var q = await _context.Questions.FirstAsync(x => x.Id == newQuestion.Id);

            q.Name = newQuestion.Name;
            q.Answer = newQuestion.Answer;
            q.Ord = newQuestion.Ord;
            q.Visible = newQuestion.Visible;

            await _context.SaveChangesAsync();
        }
        public async Task UpdateIncludeAsync(Include newInclude)
        {
            var q = await _context.Includes.FirstAsync(x => x.Id == newInclude.Id);

            q.Number = newInclude.Number;
            q.Text = newInclude.Text;
            q.Visible = newInclude.Visible;

            await _context.SaveChangesAsync();
        }

        public async Task InsertTourAsync(Tour tour)
        {
            await _context.Tours.AddAsync(tour);
            await _context.SaveChangesAsync();
        }
        public async Task InsertViewAsync(View view)
        {
            await _context.Views.AddAsync(view);
            await _context.SaveChangesAsync();
        }

        public async Task<View> GetViewByIdAsync(Guid Id)
        {
            var t = await _context.Views.AsNoTracking().FirstAsync(x => x.Id == Id);
            return t;
        }
        public async Task InsertImageAsync(Image img)
        {
            await _context.Images.AddAsync(img);
            await _context.SaveChangesAsync();
        }
        public async Task InsertDayAsync(Day day)
        {
            await _context.Days.AddAsync(day);
            await _context.SaveChangesAsync();
        }
        public async Task InsertReviewAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }
        public async Task InsertQuestionAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }
        public async Task InsertIncludeAsync(Include include)
        {
            await _context.Includes.AddAsync(include);
            await _context.SaveChangesAsync();
        }

        public async Task<Image> GetImageByIdAsync(Guid Id)
        {
            var t = await _context.Images.AsNoTracking().FirstAsync(x => x.Id == Id);
            return t;
        }
        public async Task<Day> GetDayByIdAsync(Guid Id)
        {
            var t = await _context.Days.AsNoTracking().FirstAsync(x => x.Id == Id);
            return t;
        }
        public async Task<Review> GetReviewByIdAsync(Guid Id)
        {
            var t = await _context.Reviews.AsNoTracking().FirstAsync(x => x.Id == Id);
            return t;
        }
        public async Task<Question> GetQuestionByIdAsync(Guid Id)
        {
            var q = await _context.Questions.AsNoTracking().FirstAsync(x => x.Id == Id);
            return q;
        }
        public async Task<Include> GetIncludeByIdAsync(Guid Id)
        {
            var i = await _context.Includes.AsNoTracking().FirstAsync(x => x.Id == Id);
            return i;
        }
    }
}
