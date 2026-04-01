using BuildingBlock.Core.Application.CQRS;
using OrderManagement.Core.Application.Users.CQRS.Queries.Requests;
using OrderManagement.Core.Application.Users.DTOs;
using OrderManagement.Core.Domain.UserAggregate.Repositories;

namespace OrderManagement.Core.Application.Users.CQRS.Queries.Handlers;

public class GetUserDistributionQueryHandler : IQueryHandler<GetUserDistributionQuery, List<LocationUserCountDto>>
{
    private readonly IShippingAddressReadOnlyRepository _shippingAddressReadOnlyRepository;

    public GetUserDistributionQueryHandler(IShippingAddressReadOnlyRepository shippingAddressReadOnlyRepository)
    {
        _shippingAddressReadOnlyRepository = shippingAddressReadOnlyRepository;
    }

    public async Task<List<LocationUserCountDto>> Handle(GetUserDistributionQuery request,
        CancellationToken cancellationToken)
    {
        Dictionary<Guid, (double Lat, double Lng)> coordinates = new()
        {
            { Guid.Parse("04ce6eed-86cb-477d-8483-635219d20845"), (9.60252, 105.97391) }, // Hậu Giang,
            { Guid.Parse("072ca990-da92-4fcb-b36b-c7e9aa566d69"), (21.36088, 105.54744) }, // Vĩnh Phúc,
            { Guid.Parse("078c7488-a529-45b3-8e4f-2230d3002f5c"), (21.27584, 106.20028) }, // Bắc Giang,
            { Guid.Parse("0db4469d-eff6-43d1-943a-a805c536f0dc"), (17.50000, 106.33300) }, // Quảng Bình,
            { Guid.Parse("1d0ff073-1ba8-49d9-84a8-534083e19db6"), (20.42037, 106.16223) }, // Nam Định,
            { Guid.Parse("1dfd3cb9-e4a7-48b4-a3dc-75b7463cec4e"), (21.02680, 105.83520) }, // Bắc Ninh,
            { Guid.Parse("23643eb5-d9f7-4a11-8472-8771f79e4554"), (9.25156, 105.51365) }, // Cà Mau,
            { Guid.Parse("24a2ffca-1a6b-403a-994e-0df757c64e8c"), (21.02851, 105.80482) }, // Hà Nội,
            { Guid.Parse("24db5a42-bc14-47f7-8770-767fa64f04ea"), (20.95990, 107.04254) }, // Quảng Ninh,
            { Guid.Parse("2d87a6dc-823c-42b7-a650-98abff76038f"), (15.57430, 108.48160) }, // Quảng Nam,
            { Guid.Parse("30794687-dbdb-44cb-95b9-f23dfeac2afb"), (10.53574, 106.41366) }, // Long An,
            { Guid.Parse("3165cf8d-8bc7-4f25-a4f9-3ec43891be55"), (16.05441, 108.20217) }, // Đà Nẵng,
            { Guid.Parse("3a16e152-f391-4504-8459-ca08eaea6556"), (22.69629, 104.98052) }, // Hà Giang,
            { Guid.Parse("3a779802-c972-421d-9ffb-e67776739d56"), (12.19139, 107.55240) }, // Đắk Nông,
            { Guid.Parse("3d1f7655-c9fe-40ab-9e2f-952b882c2400"), (14.35558, 107.99423) }, // Kon Tum,
            { Guid.Parse("3f3137a3-e6d4-405e-a46b-d956a0297a4b"), (11.36778, 106.11889) }, // Tây Ninh,
            { Guid.Parse("3ff2d395-bb52-422b-87ef-ef72553487ff"), (9.88374, 106.34295) }, // Trà Vinh,
            { Guid.Parse("4072161f-91d2-4241-af1f-ce08b7938425"), (22.48333, 103.86667) }, // Lào Cai,
            { Guid.Parse("40fc472b-20cb-4283-8c81-fcbcabcfa31c"), (20.59968, 106.04420) }, // Hưng Yên,
            { Guid.Parse("418b0e03-577a-4902-aee8-68121813a140"), (21.36095, 103.02567) }, // Điện Biên,
            { Guid.Parse("4232e484-67d8-4a0e-b0dc-942cbde7affb"), (15.12050, 108.79590) }, // Quảng Ngãi,
            { Guid.Parse("43b1409f-1bd3-45a2-a7a3-b6101934f1b8"), (13.53307, 108.00241) }, // Gia Lai,
            { Guid.Parse("4d45812d-be7b-4ce1-9f79-9e7a97047786"), (19.23425, 104.92004) }, // Nghệ An,
            { Guid.Parse("4f3e6736-cbc3-46ba-af69-4e4fcefc6e5e"), (20.45153, 106.33958) }, // Thái Bình,
            { Guid.Parse("5050d42b-3734-458b-808d-36ba27a83c62"), (9.60252, 105.97391) }, // Sóc Trăng,
            { Guid.Parse("511b62ca-c100-4d99-bedb-00969f31f390"), (10.39456, 106.37423) }, // Bến Tre,
            { Guid.Parse("529c2aec-8ab6-4350-9684-a14b44892654"), (18.34280, 105.90569) }, // Hà Tĩnh,
            { Guid.Parse("52b66b6d-482e-4b19-b309-a14c2be007c8"), (13.08819, 109.09288) }, // Phú Yên,
            { Guid.Parse("53f8ca89-bd97-413b-bcba-093086ce3ed0"), (20.81904, 105.33846) }, // Hòa Bình,
            { Guid.Parse("549c2cf9-426e-46d8-8d1b-154e31e1bc32"), (21.32573, 104.11610) }, // Sơn La,
            { Guid.Parse("629db267-7376-47ec-b8b0-b01587d07f13"), (21.68908, 104.98711) }, // Yên Bái,
            { Guid.Parse("6dc2c828-4778-44ad-aa77-5fc06b52ab37"), (10.04516, 105.74686) }, // Cần Thơ,
            { Guid.Parse("6e19afca-428c-4fd5-8407-1ef1fbf1429c"), (16.99570, 107.18400) }, // Quảng Trị,
            { Guid.Parse("7dd6a7bf-24be-42cd-908d-c0e8666d89e8"), (11.49860, 106.80052) }, // Bình Phước,
            { Guid.Parse("86a41886-982e-4cce-82df-50bf2baa9abc"), (16.46371, 107.59087) }, // Thừa Thiên Huế,
            { Guid.Parse("94b08511-b14a-45cb-9052-e7ef518fccc9"), (20.25006, 105.93833) }, // Ninh Bình,
            { Guid.Parse("95a1f0c7-a438-4aad-b4cf-26de47e5010e"), (10.96411, 106.85646) }, // Đồng Nai,
            { Guid.Parse("a4c42fbd-1dd6-4abf-ad12-49260d6dc0e2"), (21.85631, 106.75757) }, // Lạng Sơn,
            { Guid.Parse("b25953a6-7d22-4fdd-9578-06ee80eb6a3b"), (20.55280, 106.17718) }, // Hà Nam,
            { Guid.Parse("b84a0c16-5338-42b5-b9ad-8d0300f97948"), (10.24602, 105.22674) }, // An Giang,
            { Guid.Parse("b868ef18-6c1e-469d-86d3-cce9f0fce5a4"), (9.91228, 105.98131) }, // Vĩnh Long,
            { Guid.Parse("bc888c1b-66be-4ece-83d4-d71788c6c6bd"), (20.86514, 106.68383) }, // Hải Phòng,
            { Guid.Parse("c3926b3f-624d-4797-aaa9-33d6ccab7f83"), (10.46805, 105.63378) }, // Đồng Tháp,
            { Guid.Parse("c4d350c2-a277-4083-8adc-6af48b7b372f"), (21.79550, 105.21550) }, // Tuyên Quang,
            { Guid.Parse("c4e0324c-0006-496e-ab41-f95ca70cf2dd"), (11.56750, 108.98862) }, // Ninh Thuận,
            { Guid.Parse("c5e7e75d-3993-4ed4-b4df-dc82f262a101"), (22.66667, 106.25000) }, // Cao Bằng,
            { Guid.Parse("c6153af4-48e4-4adb-84f8-ae406b644dd7"), (21.59010, 105.81350) }, // Thái Nguyên,
            { Guid.Parse("ce88b551-8f7f-4414-90e5-5f4ae1d4000b"), (10.76262, 106.66017) }, // Hồ Chí Minh,
            { Guid.Parse("d0d78052-dce0-4fc8-8cd5-ddb9233ade5a"), (14.16700, 109.00000) }, // Bình Định,
            { Guid.Parse("d30c3fda-05ea-4c09-a343-2d10cd30c7fe"), (10.92842, 108.12007) }, // Bình Thuận,
            { Guid.Parse("d70a80ea-09fd-4977-a479-dcc75c9dc382"), (10.02868, 105.21790) }, // Kiên Giang,
            { Guid.Parse("d717b8a4-7cf3-4f73-8f88-fad7c14b31c3"), (12.24964, 109.19712) }, // Khánh Hòa,
            { Guid.Parse("de9fa72c-d0f1-4fad-a65d-1e7d94d1618d"), (10.50458, 107.16921) }, // Bà Rịa - Vũng Tàu,
            { Guid.Parse("e5b691ae-cf12-40c4-90a6-ba32c7f5a9a1"), (12.68080, 108.05095) }, // Đắk Lắk,
            { Guid.Parse("e8f3eb69-d9de-4491-8465-d206c8fb44b5"), (10.51025, 106.37904) }, // Tiền Giang,
            { Guid.Parse("eaca1d11-c10c-43a6-8395-00eda73feb0d"), (9.25156, 105.51365) }, // Bạc Liêu,
            { Guid.Parse("ebc8e30c-46fa-4243-8e96-f0f72791d7b1"), (20.94553, 106.33464) }, // Hải Dương,
            { Guid.Parse("ec51b494-c2ba-4f7c-9a2a-05dd47a6df4b"), (11.93454, 108.44147) }, // Lâm Đồng,
            { Guid.Parse("f2a17db0-9844-4537-bdaa-7b231abb9cd4"), (21.47206, 103.94619) }, // Lai Châu,
            { Guid.Parse("f78056fa-dc76-4133-a4c7-362b9650a083"), (21.36556, 105.12649) }, // Phú Thọ,
            { Guid.Parse("f965e113-c1e9-4efe-8b11-8fbc958308c6"), (19.80669, 105.78518) }, // Thanh Hóa,
            { Guid.Parse("f9e98bd8-ac52-47ef-ba86-b5119cb89ba8"), (22.14714, 105.83480) }, // Bắc Cạn,
            { Guid.Parse("fca17678-a99a-4f05-bbd0-20c8c827c7ca"), (11.32540, 106.47700) } // Bình Dương
        };

        var results = await _shippingAddressReadOnlyRepository.GetUserDistributionAsync();
        
     
        return results
            .Where(r => coordinates.TryGetValue(r.Province.Id, out _))
            .Select(r =>
            {
                var coord = coordinates[r.Province.Id];
                return new LocationUserCountDto
                {
                    Id = r.Province.Id,
                    Province = r.Province.Name,
                    Lat = coord.Lat,
                    Lng = coord.Lng,
                    Count = r.UserCount
                };
            })
            .ToList();
    }
}